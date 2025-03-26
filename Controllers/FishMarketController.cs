using FishReportApi.Data;
using FishReportApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishReportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishMarketController : ControllerBase
    {
        private readonly FishDBContext _context;

        public FishMarketController(FishDBContext context)
        {
            _context = context;
        }

        // GET: api/fishmarket
        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var markets = await _context.FishMarkets
                .Include(m => m.Species)
                .ToListAsync();

            return Ok(markets);
        }

        // GET: api/fishmarket/{id}
        [HttpGet("marketid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var market = await _context.FishMarkets
                .Include(m => m.Species)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (market == null) return NotFound();

            return Ok(market);
        }

        // POST: api/fishmarket
        [HttpPost("createmarket")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] FishMarket market)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.FishMarkets.AddAsync(market);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = market.Id }, market);
        }

        // PUT: api/fishmarket/{id}
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] FishMarket updatedMarket)
        {
            if (id != updatedMarket.Id)
                return BadRequest("ID mismatch");

            var existingMarket = await _context.FishMarkets.FindAsync(id);
            if (existingMarket == null) return NotFound();

            _context.Entry(existingMarket).CurrentValues.SetValues(updatedMarket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/fishmarket/{id}
        [HttpPatch("updatepartial/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<FishMarket> patchDoc)
        {
            var market = await _context.FishMarkets.FindAsync(id);
            if (market == null) return NotFound();

            patchDoc.ApplyTo(market, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/fishmarket/{id}
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var market = await _context.FishMarkets.FindAsync(id);
            if (market == null) return NotFound();

            _context.FishMarkets.Remove(market);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}