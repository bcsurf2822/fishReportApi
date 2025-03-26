using FishReportApi.Models;

namespace FishReportApi.Repositories.Interfaces
{
    public interface IFishMarketRepository
    {
        Task<IEnumerable<FishMarket>> GetAllAsync();
        Task<FishMarket?> GetByIdAsync(int id);
        Task<FishMarket> CreateAsync(FishMarket market);
        Task<bool> UpdateAsync(FishMarket market);
        Task<bool> DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}