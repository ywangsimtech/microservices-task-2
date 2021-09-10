using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBooking.Models;

namespace MovieBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookingsController : ControllerBase
    {
        private readonly bookingContext _context;

        public bookingsController(bookingContext context)
        {
            _context = context;
        }

        // GET: api/bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<booking>>> Getbooking()
        {
            return await _context.booking.ToListAsync();
        }

        // GET: api/bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<booking>> Getbooking(long id)
        {
            var booking = await _context.booking.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // PUT: api/bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbooking(long id, booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<booking>> Postbooking(booking booking)
        {
            _context.booking.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Getbooking), new { id = booking.Id }, booking);
        }

        // DELETE: api/bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebooking(long id)
        {
            var booking = await _context.booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.booking.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool bookingExists(long id)
        {
            return _context.booking.Any(e => e.Id == id);
        }
    }
}
