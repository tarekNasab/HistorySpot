using HistorySpot.Models;

namespace HistorySpot.Repositories
{
    public interface IHistoricalPointRepository
    {
        Task<IEnumerable<HistoricalPoint>> GetAllAsync();
        Task<HistoricalPoint> GetAsync(Guid id);
        Task<HistoricalPoint> AddAsync(HistoricalPoint historicalPoint);
        Task<HistoricalPoint?> UpdateAsync(HistoricalPoint historicalPoint);
        Task<HistoricalPoint> DeleteAsync(Guid id);

    }
}
