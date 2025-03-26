using FishReportApi.Data;
using FishReportApi.Models;
using FishReportApi.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace FishReportApi.Repositories
{
    public class FishRepository : IFishRepository
    {
        private readonly FishDBContext _context;

        public FishRepository(FishDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Species>> GetAllAsync()
        {
            return await _context.Species.ToListAsync();
        }

        public async Task<Species?> GetByIdAsync(int id)
        {
            return await _context.Species.FindAsync(id);
        }

        public async Task<Species> CreateAsync(Species fish)
        {
            await _context.Species.AddAsync(fish);
            return fish;
        }

        public async Task<bool> UpdateAsync(Species fish)
        {
            var existing = await _context.Species.FindAsync(fish.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(fish);
            return true;
        }

        public async Task<bool> PatchAsync(int id, JsonPatchDocument<Species> patchDoc, ModelStateDictionary modelState)
        {
            var fish = await _context.Species.FindAsync(id);
            if (fish == null) return false;

            patchDoc.ApplyTo(fish, modelState);

            if (!modelState.IsValid)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var fish = await _context.Species.FindAsync(id);
            if (fish == null) return false;

            _context.Species.Remove(fish);
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}