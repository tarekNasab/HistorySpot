namespace HistorySpot.Repositories
{
    public interface ILikeRepository
    {
        Task<string?> GetByUrlHandleAsync(string urlHandle);
        Task<int> GetTotalLikes(Guid historicalPointId);
    }
}
