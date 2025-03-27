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

        public async Task<bool> AddSpeciesToMarketAsync(int marketId, int speciesId)
        {
            var market = await _context.FishMarkets
                .Include(m => m.FishMarketInventory)
                .FirstOrDefaultAsync(m => m.Id == marketId);

            var species = await _context.Species.FindAsync(speciesId);

            if (market == null || species == null)
            {
                return false; // Return false if market or species doesn't exist
            }

            // Check if species is already in the market
            if (market.FishMarketInventory.Any(fmi => fmi.SpeciesId == speciesId))
            {
                return false; // Prevent duplicate entries
            }

            // Add species to the inventory
            _context.FishMarketInventory.Add(new FishMarketInventory
            {
                FishMarketId = marketId,
                SpeciesId = speciesId
            });

            await _context.SaveChangesAsync();
            return true;
        }
    }
}