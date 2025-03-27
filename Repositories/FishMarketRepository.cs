using FishReportApi.Data;
using FishReportApi.Models;
using FishReportApi.Repositories.Interfaces;

namespace FishReportApi.Repositories
{
    public class FishMarketRepository : CommonRepository<FishMarket>, IFishMarketRepository
    {
        public FishMarketRepository(FishDBContext context) : base(context)
        {
        }
    }
}