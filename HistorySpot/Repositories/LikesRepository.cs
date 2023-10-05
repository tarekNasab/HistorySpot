using HistorySpot.Data;
using Microsoft.EntityFrameworkCore;

namespace HistorySpot.Repositories
{
    public class LikesRepository : ILikeRepository
    {
        private readonly HistorySpotDbContext historySpotDbContext;

        public LikesRepository(HistorySpotDbContext historySpotDbContext)
        {
            this.historySpotDbContext = historySpotDbContext;
        }

        public Task<string?> GetByUrlHandleAsync(string urlHandle)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalLikes(Guid historicalPointId)
        {
           return  await historySpotDbContext.likes
                .CountAsync(x => x.HistoricalPointId == historicalPointId);
        }
    }
}
