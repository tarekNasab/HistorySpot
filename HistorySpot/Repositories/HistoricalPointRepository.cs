using HistorySpot.Data;
using HistorySpot.Models;
using HistorySpot.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HistorySpot.Repositories
{
    public class HistoricalPointRepository : IHistoricalPointRepository
    {
        private readonly HistorySpotDbContext historySpotDbContext;

        public HistoricalPointRepository(HistorySpotDbContext historySpotDbContext)
        {
            this.historySpotDbContext = historySpotDbContext;
        }
        public async Task<HistoricalPoint> AddAsync(HistoricalPoint historicalPoint)
        {
            await historySpotDbContext.historicalPoints.AddAsync(historicalPoint);
            await historySpotDbContext.SaveChangesAsync();
            return historicalPoint;
        }

        public async Task<HistoricalPoint?> DeleteAsync(Guid id)
        {
            var ExistingHistoricalPoint = await historySpotDbContext.historicalPoints.FindAsync(id);
            if (ExistingHistoricalPoint != null)
            {
                historySpotDbContext.historicalPoints.Remove(ExistingHistoricalPoint);
                await historySpotDbContext.SaveChangesAsync();
                return ExistingHistoricalPoint;
            }
            return null;
        }

        public async Task<IEnumerable<HistoricalPoint>> GetAllAsync()
        {
            return await historySpotDbContext.historicalPoints.ToListAsync();
         
        }

        public Task<HistoricalPoint> GetAsync(Guid id)
        {
           return historySpotDbContext.historicalPoints.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<HistoricalPoint?> UpdateAsync(HistoricalPoint historicalPoint)
        {
           var existingHistoricalPoint = await historySpotDbContext.historicalPoints.FindAsync(historicalPoint.Id);
            if (existingHistoricalPoint != null)
            {
                existingHistoricalPoint.Id = historicalPoint.Id;
                existingHistoricalPoint.Name=historicalPoint.Name;
                existingHistoricalPoint.Description=historicalPoint.Description;
                existingHistoricalPoint.Latitude=historicalPoint.Latitude;
                existingHistoricalPoint.Longitude=historicalPoint.Longitude;
                existingHistoricalPoint.ImageUrl=historicalPoint.ImageUrl;
                existingHistoricalPoint.Date=historicalPoint.Date;
                await historySpotDbContext.SaveChangesAsync();
                return existingHistoricalPoint;
            }
            return null;
        }
       
    }
}
