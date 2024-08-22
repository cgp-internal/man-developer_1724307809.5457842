using DataAccess;
using Models;
using System.Threading.Tasks;

namespace Services
{
    public interface IChargingStationService
    {
        Task<BootNotificationResponse> BootNotification(BootNotificationRequest request);
        Task<AuthorizeResponse> Authorize(AuthorizeRequest request);
        Task StartTransaction(StartTransactionRequest request);
        Task StopTransaction(StopTransactionRequest request);
        Task Heartbeat();
        Task MeterValues(MeterValuesRequest request);
        Task StatusNotification(StatusNotificationRequest request);
    }

    public class ChargingStationService : IChargingStationService
    {
        private readonly IChargingStationRepository _repository;

        public ChargingStationService(IChargingStationRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<BootNotificationResponse> BootNotification(BootNotificationRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var station = await _repository.GetChargingStation(request.ChargingStationId);
            return station != null 
                ? new BootNotificationResponse { Status = "Accepted" } 
                : new BootNotificationResponse { Status = "Rejected" };
        }

        public async Task<AuthorizeResponse> Authorize(AuthorizeRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var station = await _repository.GetChargingStation(request.ChargingStationId);
            return station != null 
                ? new AuthorizeResponse { IdTagInfo = new IdTagInfo { Status = "Accepted" } } 
                : new AuthorizeResponse { IdTagInfo = new IdTagInfo { Status = "Rejected" } };
        }

        public async Task StartTransaction(StartTransactionRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var station = await _repository.GetChargingStation(request.ChargingStationId);
            if (station != null)
            {
                // Start transaction logic
                await _repository.UpdateChargingStationStatus(request.ChargingStationId, "InTransaction");
            }
        }

        public async Task StopTransaction(StopTransactionRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var station = await _repository.GetChargingStation(request.ChargingStationId);
            if (station != null)
            {
                // Stop transaction logic
                await _repository.UpdateChargingStationStatus(request.ChargingStationId, "Available");
            }
        }

        public async Task Heartbeat()
        {
            // Heartbeat logic
        }

        public async Task MeterValues(MeterValuesRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            // Meter values logic
        }

        public async Task StatusNotification(StatusNotificationRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var station = await _repository.GetChargingStation(request.ChargingStationId);
            if (station != null)
            {
                await _repository.UpdateChargingStationStatus(request.ChargingStationId, request.Status);
            }
        }
    }
}