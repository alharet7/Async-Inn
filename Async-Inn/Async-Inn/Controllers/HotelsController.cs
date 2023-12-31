﻿using System;
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
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel hotel)
        {
            _hotel = hotel;
        }

        // GET: api/Hotels
        [Authorize(Policy = "read")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            if (_hotel == null)
            {
                return NotFound();
            }
            return await _hotel.GetHotel();
        }

        // GET: api/Hotels/5
        [Authorize(Policy = "read")]
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            if (_hotel == null)
            {
                return NotFound();
            }
            var hotel = await _hotel.GetHotelById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = "update")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel([FromRoute] int id, [FromBody] Hotel hotel)
        {
            var updatedHotel = _hotel.UpDateHotel(id, hotel);

            return Ok(updatedHotel);
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = "create")]
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            if (_hotel == null)
            {
                return Problem("Entity set 'AsyncInnDbContext.Hotels'  is null.");
            }
            await _hotel.Create(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [Authorize(Policy = "delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (_hotel == null)
            {
                return NotFound();
            }
            await _hotel.Delete(id);

            return NoContent();
        }


    }
}
