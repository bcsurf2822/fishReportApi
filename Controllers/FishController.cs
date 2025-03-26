using FishReportApi.Data;
using FishReportApi.Models;
using FishReportApi.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishReportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishController : ControllerBase
    {
        private readonly IFishRepository _repository;
        public FishController(IFishRepository repository)
        {
            _repository = repository;
        }


        //GET ALL FISH
        [HttpGet("getAllFish")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllFish()
        {
            var fishList = await _repository.GetAllAsync();
            return Ok(fishList);
        }

        //GET FISH
        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFishById(int id)
        {
            var fish = await _repository.GetByIdAsync(id);
            if (fish == null) return NotFound();
            return Ok(fish);
        }

        //POST FISH
        [HttpPost("createFish")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateFish([FromBody] Species fish)
        {
            await _repository.CreateAsync(fish);
            await _repository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFishById), new { id = fish.Id }, fish);
        }


        //PUT | UPDATE FULL
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateFish(int id, [FromBody] Species fish)
        {
            if (id != fish.Id) return BadRequest("ID mismatch");

            var success = await _repository.UpdateAsync(fish);
            if (!success) return NotFound();

            await _repository.SaveChangesAsync();
            return NoContent();
        }


        //PATCH | Update Partial
        [HttpPatch("updatePartial/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchFish(int id, [FromBody] JsonPatchDocument<Species> patchDoc)
        {
            var success = await _repository.PatchAsync(id, patchDoc, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!success)
                return NotFound();

            await _repository.SaveChangesAsync();
            return NoContent();
        }


        //DELETE | Fish
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFish(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success) return NotFound();

            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}