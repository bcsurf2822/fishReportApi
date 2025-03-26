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
        [HttpGet("getAllFish")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllFish()
        {
            var fishList = await _context.Species.ToListAsync();
            return Ok(fishList);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFishById(int id)
        {
            var fish = await _context.Species.FindAsync(id);

            if (fish == null)
            {
                return NotFound($"No fish with {id}");
            }
            return Ok(fish);
        }
    }
}