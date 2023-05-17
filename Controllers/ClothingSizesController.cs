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
    [Route("api/clothingSize")]
    [ApiController]
    public class ClothingSizesController : ControllerBase
    {
        private readonly TrendyThreadsContext _context;

        public ClothingSizesController(TrendyThreadsContext context)
        {
            _context = context;
        }

        // GET: api/ClothingSizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingSize>>> GetClothingSizes()
        {
          if (_context.ClothingSizes == null)
          {
              return NotFound();
          }
            return await _context.ClothingSizes.ToListAsync();
        }

        // GET: api/ClothingSizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingSize>> GetClothingSize(long id)
        {
          if (_context.ClothingSizes == null)
          {
              return NotFound();
          }
            var clothingSize = await _context.ClothingSizes.FindAsync(id);

            if (clothingSize == null)
            {
                return NotFound();
            }

            return clothingSize;
        }

        // PUT: api/ClothingSizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothingSize(long id, ClothingSize clothingSize)
        {
            if (id != clothingSize.ClothingSizeId)
            {
                return BadRequest();
            }

            _context.Entry(clothingSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingSizeExists(id))
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

        // POST: api/ClothingSizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothingSize>> PostClothingSize(ClothingSize clothingSize)
        {
          if (_context.ClothingSizes == null)
          {
              return Problem("Entity set 'TrendyThreadsContext.ClothingSizes'  is null.");
          }
            _context.ClothingSizes.Add(clothingSize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothingSize", new { id = clothingSize.ClothingSizeId }, clothingSize);
        }

        // DELETE: api/ClothingSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingSize(long id)
        {
            if (_context.ClothingSizes == null)
            {
                return NotFound();
            }
            var clothingSize = await _context.ClothingSizes.FindAsync(id);
            if (clothingSize == null)
            {
                return NotFound();
            }

            _context.ClothingSizes.Remove(clothingSize);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingSizeExists(long id)
        {
            return (_context.ClothingSizes?.Any(e => e.ClothingSizeId == id)).GetValueOrDefault();
        }
    }
}
