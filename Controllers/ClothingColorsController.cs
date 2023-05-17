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
    [Route("api/clothingColor")]
    [ApiController]
    public class ClothingColorsController : ControllerBase
    {
        private readonly TrendyThreadsContext _context;

        public ClothingColorsController(TrendyThreadsContext context)
        {
            _context = context;
        }

        // GET: api/ClothingColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingColor>>> GetClothingColors()
        {
          if (_context.ClothingColors == null)
          {
              return NotFound();
          }
            return await _context.ClothingColors.ToListAsync();
        }

        // GET: api/ClothingColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingColor>> GetClothingColor(long id)
        {
          if (_context.ClothingColors == null)
          {
              return NotFound();
          }
            var clothingColor = await _context.ClothingColors.FindAsync(id);

            if (clothingColor == null)
            {
                return NotFound();
            }

            return clothingColor;
        }

        // PUT: api/ClothingColors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothingColor(long id, ClothingColor clothingColor)
        {
            if (id != clothingColor.ClothingColorId)
            {
                return BadRequest();
            }

            _context.Entry(clothingColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingColorExists(id))
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

        // POST: api/ClothingColors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothingColor>> PostClothingColor(ClothingColor clothingColor)
        {
          if (_context.ClothingColors == null)
          {
              return Problem("Entity set 'TrendyThreadsContext.ClothingColors'  is null.");
          }
            _context.ClothingColors.Add(clothingColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothingColor", new { id = clothingColor.ClothingColorId }, clothingColor);
        }

        // DELETE: api/ClothingColors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingColor(long id)
        {
            if (_context.ClothingColors == null)
            {
                return NotFound();
            }
            var clothingColor = await _context.ClothingColors.FindAsync(id);
            if (clothingColor == null)
            {
                return NotFound();
            }

            _context.ClothingColors.Remove(clothingColor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingColorExists(long id)
        {
            return (_context.ClothingColors?.Any(e => e.ClothingColorId == id)).GetValueOrDefault();
        }
    }
}
