using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrendyThreads.Models;

namespace TrendyThreads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartClothingsController : ControllerBase
    {
        private readonly TrendyThreadsContext _context;

        public CartClothingsController(TrendyThreadsContext context)
        {
            _context = context;
        }

        // GET: api/CartClothings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartClothing>>> GetCartClothings()
        {
          if (_context.CartClothings == null)
          {
              return NotFound();
          }
            return await _context.CartClothings.ToListAsync();
        }

        // GET: api/CartClothings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartClothing>> GetCartClothing(long id)
        {
          if (_context.CartClothings == null)
          {
              return NotFound();
          }
            var cartClothing = await _context.CartClothings.FindAsync(id);

            if (cartClothing == null)
            {
                return NotFound();
            }

            return cartClothing;
        }

        // PUT: api/CartClothings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartClothing(long id, CartClothing cartClothing)
        {
            if (id != cartClothing.CartClothingId)
            {
                return BadRequest();
            }

            _context.Entry(cartClothing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartClothingExists(id))
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

        // POST: api/CartClothings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartClothing>> PostCartClothing(CartClothing cartClothing)
        {
          if (_context.CartClothings == null)
          {
              return Problem("Entity set 'TrendyThreadsContext.CartClothings'  is null.");
          }
            _context.CartClothings.Add(cartClothing);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartClothingExists(cartClothing.CartClothingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCartClothing", new { id = cartClothing.CartClothingId }, cartClothing);
        }

        // DELETE: api/CartClothings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartClothing(long id)
        {
            if (_context.CartClothings == null)
            {
                return NotFound();
            }
            var cartClothing = await _context.CartClothings.FindAsync(id);
            if (cartClothing == null)
            {
                return NotFound();
            }

            _context.CartClothings.Remove(cartClothing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartClothingExists(long id)
        {
            return (_context.CartClothings?.Any(e => e.CartClothingId == id)).GetValueOrDefault();
        }
    }
}
