using FishReportApi.Data;
using FishReportApi.Models;
using FishReportApi.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace FishReportApi.Repositories
{
    public class FishRepository : GenericRepository<Species>, IFishRepository
    {
        public FishRepository(FishDBContext context) : base(context)
        {
        }

        public Task<bool> PatchAsync(int id, JsonPatchDocument<Species> patchDoc, ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }
}