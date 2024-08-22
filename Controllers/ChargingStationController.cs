using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingStationController : ControllerBase
    {
        private readonly IChargingStationService _chargingStationService;

        public ChargingStationController(IChargingStationService chargingStationService)
        {
            _chargingStationService = chargingStationService ?? throw new ArgumentNullException(nameof(chargingStationService));
        }

        [HttpPost("BootNotification")]
        public async Task<IActionResult> BootNotification([FromBody] BootNotificationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _chargingStationService.BootNotification(request);
            return Ok(response);
        }

        [HttpPost("Authorize")]
        public async Task<IActionResult> Authorize([FromBody] AuthorizeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _chargingStationService.Authorize(request);
            return Ok(response);
        }

        [HttpPost("StartTransaction")]
        public async Task<IActionResult> StartTransaction([FromBody] StartTransactionRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _chargingStationService.StartTransaction(request);
            return Ok();
        }

        [HttpPost("StopTransaction")]
        public async Task<IActionResult> StopTransaction([FromBody] StopTransactionRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _chargingStationService.StopTransaction(request);
            return Ok();
        }

        [HttpPost("Heartbeat")]
        public async Task<IActionResult> Heartbeat()
        {
            await _chargingStationService.Heartbeat();
            return Ok();
        }

        [HttpPost("MeterValues")]
        public async Task<IActionResult> MeterValues([FromBody] MeterValuesRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _chargingStationService.MeterValues(request);
            return Ok();
        }

        [HttpPost("StatusNotification")]
        public async Task<IActionResult> StatusNotification([FromBody] StatusNotificationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _chargingStationService.StatusNotification(request);
            return Ok();
        }
    }
}