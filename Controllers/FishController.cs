using FishReportApi.Data;
using FishReportApi.Models;
using Microsoft.AspNetCore.JsonPatch;
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


        //GET ALL FISH
        [HttpGet("getAllFish")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllFish()
        {
            var fishList = await _context.Species.ToListAsync();
            return Ok(fishList);
        }

        //GET FISH
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

        //POST FISH
        [HttpPost("createFish")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateFish([FromBody] Species species)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Species.AddAsync(species);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFishById), new { id = species.Id }, species);
        }


        //PUT | UPDATE FULL
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateFish(int id, [FromBody] Species updatedFish)
        {
            if (id != updatedFish.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingFish = await _context.Species.FindAsync(id);
            if (existingFish == null)
            {
                return NotFound();
            }

            existingFish.Name = updatedFish.Name;
            existingFish.Habitat = updatedFish.Habitat;
            existingFish.Length = updatedFish.Length;
            existingFish.Population = updatedFish.Population;
            existingFish.Lifespan = updatedFish.Lifespan;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        //PATCH | Update Partial
        [HttpPatch("updatePartial/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchFish(int id, [FromBody] JsonPatchDocument<Species> patchDoc)
        {
            var existingFish = await _context.Species.FindAsync(id);
            if (existingFish == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(existingFish, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }


        //DELETE | Fish
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFish(int id)
        {
            var fish = await _context.Species.FindAsync(id);
            if (fish == null)
            {
                return NotFound($"No fish found with ID {id}");
            }

            _context.Species.Remove(fish);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}