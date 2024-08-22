using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public interface IChargingStationRepository
    {
        Task<ChargingStation> GetChargingStation(int id);
        Task UpdateChargingStationStatus(int id, string status);
    }

    public class ChargingStationRepository : IChargingStationRepository
    {
        private readonly ChargingStationDBContext _context;

        public ChargingStationRepository(ChargingStationDBContext context)
        {
            _context = context;
        }

        public async Task<ChargingStation> GetChargingStation(int id)
        {
            return await _context.ChargingStations.FindAsync(id);
        }

        public async Task UpdateChargingStationStatus(int id, string status)
        {
            var station = await _context.ChargingStations.FindAsync(id);
            if (station != null)
            {
                station.Status = status;
                await _context.SaveChangesAsync();
            }
        }
    }
}