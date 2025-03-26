using FishReportApi.Data;
using FishReportApi.Models;
using FishReportApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FishReportApi.Repositories
{
    public class FishMarketRepository : IFishMarketRepository
    {
        private readonly FishDBContext _context;

        public FishMarketRepository(FishDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FishMarket>> GetAllAsync()
        {
            return await _context.FishMarkets
                .Include(m => m.Species)
                .ToListAsync();
        }

        public async Task<FishMarket?> GetByIdAsync(int id)
        {
            return await _context.FishMarkets
                .Include(m => m.Species)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<FishMarket> CreateAsync(FishMarket market)
        {
            await _context.FishMarkets.AddAsync(market);
            return market;
        }

        public async Task<bool> UpdateAsync(FishMarket market)
        {
            var existing = await _context.FishMarkets.FindAsync(market.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(market);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var market = await _context.FishMarkets.FindAsync(id);
            if (market == null) return false;

            _context.FishMarkets.Remove(market);
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}