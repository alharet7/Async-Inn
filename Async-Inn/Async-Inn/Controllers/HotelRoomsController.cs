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

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom context)
        {
            _hotelRoom = context;
        }

        // GET: api/HotelRooms
        [HttpGet]
        [Route("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms(int HotelId)
        {
            if (_hotelRoom == null)
            {
                return NotFound();
            }
            return await _hotelRoom.GetAll(HotelId);
        }

        // GET: api/HotelRooms/5
        [HttpGet("{HotelId}/Rooms/{RoomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int HotelId, int RoomNumber)
        {
            if (_hotelRoom == null)
            {
                return NotFound();
            }
            var hotelRoom = await _hotelRoom.GetHotelRoomById(HotelId, RoomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{HotelId}/Rooms/{RoomNumber}")]

        public async Task<IActionResult> PutHotelRoom(int HotelId, int RoomNumber, HotelRoomDTO hotelRoom)
        {
            if (HotelId != hotelRoom.HotelId && RoomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelRoom.UpdateHotelRoom(HotelId, RoomNumber, hotelRoom);

            return Ok(updateHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("{HotelId}/Rooms")]
        //public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        //{
        //    if (_hotelRoom == null)
        //    {
        //        return Problem("Entity set 'AsyncInnDbContext.HotelRooms'  is null.");
        //    }

        //    await _hotelRoom.Create(hotelRoom);

        //    return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelID }, hotelRoom);
        //}
        [HttpPost]
        [Route("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(HotelRoomDTO hotelRoom, int hotelId)
        {
            if (hotelRoom == null)
            {
                return Problem("the model is null or has no data ");
            }

            var addedHotelRoom = await _hotelRoom.Create(hotelRoom, hotelId);
            return Ok(addedHotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{HotelId}/Rooms/{RoomNumber}")]

        public async Task<IActionResult> DeleteHotelRoom(int HotelId, int RoomNumber)
        {
            if (_hotelRoom == null)
            {
                return NotFound();
            }

            await _hotelRoom.DeleteHotelRoom(HotelId, RoomNumber);
            return NoContent();
        }
    }
}
