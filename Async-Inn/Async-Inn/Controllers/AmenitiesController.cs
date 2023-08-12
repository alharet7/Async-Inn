using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;
using Async_Inn.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities
        [Authorize(Policy = "read")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
            if (_amenity == null)
            {
                return NotFound();
            }
            return await _amenity.GetAll();
        }

        // GET: api/Amenities/5
        [Authorize(Policy = "read")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenities(int id)
        {
            if (_amenity == null)
            {
                return NotFound();
            }
            var amenities = await _amenity.GetAmenitiesById(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return amenities;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = "update")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities([FromRoute] int Id, [FromBody] Amenities amenities)
        {
            if (Id != amenities.Id)
            {
                return BadRequest();
            }

            var updatedamenity = await _amenity.UpdateAmenitie(Id, amenities);

            return Ok(updatedamenity);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = "create")]
        [HttpPost]
        public async Task<ActionResult<AmenityDTO>> PostAmenities(AmenityDTO amenities)
        {
            if (_amenity == null)
            {
                return Problem("Entity set 'AsyncInnDbContext.Amenities'  is null.");
            }
            await _amenity.Create(amenities);

            return CreatedAtAction("GetAmenities", new { id = amenities.Id }, amenities);
        }

        // DELETE: api/Amenities/5
        [Authorize(Policy = "delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenities(int id)
        {
            if (_amenity == null)
            {
                return NotFound();
            }

            await _amenity.DeleteAmenitie(id);
            return NoContent();
        }

    }
}
