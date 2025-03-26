using FishReportApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishReportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishController : ControllerBase
    {
        private readonly FishDBContext _context;
        public FishController(FishDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFish()
        {
            var fishList = await _context.Species.ToListAsync();
            return Ok(fishList);
        }
    }
}