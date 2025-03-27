using FishReportApi.Data;
using FishReportApi.Models;
using FishReportApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FishReportApi.Repositories
{
    public class FishMarketRepository : GenericRepository<FishMarket>, IFishMarketRepository
    {
        private readonly FishDBContext _context;

        public FishMarketRepository(FishDBContext context) : base(context)
        {
            _context = context;
        }

        // Override to include species data
        public override async Task<IEnumerable<FishMarket>> GetAllAsync()
        {
            return await _context.FishMarkets
                .Include(fm => fm.FishMarketInventory)
                .ThenInclude(fmi => fmi.Species)
                .ToListAsync();
        }

        public override async Task<FishMarket?> GetByIdAsync(int id)
        {
            return await _context.FishMarkets
                .Include(fm => fm.FishMarketInventory)
                .ThenInclude(fmi => fmi.Species)
                .FirstOrDefaultAsync(fm => fm.Id == id);
        }
    }
}