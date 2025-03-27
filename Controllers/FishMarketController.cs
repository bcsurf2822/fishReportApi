using AutoMapper;
using FishReportApi.DTOs;
using FishReportApi.Models;
using FishReportApi.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FishReportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishMarketController : ControllerBase
    {
        private readonly IFishMarketRepository _repository;
        private readonly IMapper _mapper;


        public FishMarketController(IFishMarketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET
        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var markets = await _repository.GetAllAsync();
            var marketDTOs = _mapper.Map<IEnumerable<FishMarketDTO>>(markets);
            return Ok(marketDTOs);
        }

        // GET
        [HttpGet("marketid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var market = await _repository.GetByIdAsync(id);
            if (market == null) return NotFound();

            return Ok(market);
        }

        // POST
        [HttpPost("createmarket")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] FishMarket market)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.CreateAsync(market);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = market.Id }, market);
        }

        // PUT
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] FishMarket updatedMarket)
        {
            if (id != updatedMarket.Id)
                return BadRequest("ID mismatch");

            var success = await _repository.UpdateAsync(updatedMarket);
            if (!success) return NotFound();

            await _repository.SaveChangesAsync();
            return NoContent();
        }

        // PATCH
        [HttpPatch("updatepartial/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<FishMarket> patchDoc)
        {
            var market = await _repository.GetByIdAsync(id);
            if (market == null) return NotFound();

            patchDoc.ApplyTo(market, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.SaveChangesAsync();
            return NoContent();
        }

        // DELETE
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success) return NotFound();

            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}