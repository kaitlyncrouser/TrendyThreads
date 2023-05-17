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
    [Route("api/clothing")]
    [ApiController]
    public class ClothingsController : ControllerBase
    {
        private readonly TrendyThreadsContext _context;

        public ClothingsController(TrendyThreadsContext context)
        {
            _context = context;
        }

        // GET: api/Clothings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clothing>>> GetClothings()
        {
          if (_context.Clothings == null)
          {
              return NotFound();
          }
            return await _context.Clothings.ToListAsync();
        }

        // GET: api/Clothings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clothing>> GetClothing(long id)
        {
          if (_context.Clothings == null)
          {
              return NotFound();
          }
            var clothing = await _context.Clothings.FindAsync(id);

            if (clothing == null)
            {
                return NotFound();
            }

            return clothing;
        }

        // PUT: api/Clothings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothing(long id, Clothing clothing)
        {
            if (id != clothing.ClothingId)
            {
                return BadRequest();
            }

            _context.Entry(clothing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingExists(id))
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

        // POST: api/Clothings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clothing>> PostClothing(Clothing clothing)
        {
          if (_context.Clothings == null)
          {
              return Problem("Entity set 'TrendyThreadsContext.Clothings'  is null.");
          }
            _context.Clothings.Add(clothing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothing", new { id = clothing.ClothingId }, clothing);
        }

        // DELETE: api/Clothings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothing(long id)
        {
            if (_context.Clothings == null)
            {
                return NotFound();
            }
            var clothing = await _context.Clothings.FindAsync(id);
            if (clothing == null)
            {
                return NotFound();
            }

            _context.Clothings.Remove(clothing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingExists(long id)
        {
            return (_context.Clothings?.Any(e => e.ClothingId == id)).GetValueOrDefault();
        }
    }
}
