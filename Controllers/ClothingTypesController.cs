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
    [Route("api/clothingType")]
    [ApiController]
    public class ClothingTypesController : ControllerBase
    {
        private readonly TrendyThreadsContext _context;

        public ClothingTypesController(TrendyThreadsContext context)
        {
            _context = context;
        }

        // GET: api/ClothingTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingType>>> GetClothingTypes()
        {
          if (_context.ClothingTypes == null)
          {
              return NotFound();
          }
            return await _context.ClothingTypes.ToListAsync();
        }

        // GET: api/ClothingTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingType>> GetClothingType(long id)
        {
          if (_context.ClothingTypes == null)
          {
              return NotFound();
          }
            var clothingType = await _context.ClothingTypes.FindAsync(id);

            if (clothingType == null)
            {
                return NotFound();
            }

            return clothingType;
        }

        // PUT: api/ClothingTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothingType(long id, ClothingType clothingType)
        {
            if (id != clothingType.ClothingTypeId)
            {
                return BadRequest();
            }

            _context.Entry(clothingType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingTypeExists(id))
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

        // POST: api/ClothingTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothingType>> PostClothingType(ClothingType clothingType)
        {
          if (_context.ClothingTypes == null)
          {
              return Problem("Entity set 'TrendyThreadsContext.ClothingTypes'  is null.");
          }
            _context.ClothingTypes.Add(clothingType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothingType", new { id = clothingType.ClothingTypeId }, clothingType);
        }

        // DELETE: api/ClothingTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingType(long id)
        {
            if (_context.ClothingTypes == null)
            {
                return NotFound();
            }
            var clothingType = await _context.ClothingTypes.FindAsync(id);
            if (clothingType == null)
            {
                return NotFound();
            }

            _context.ClothingTypes.Remove(clothingType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingTypeExists(long id)
        {
            return (_context.ClothingTypes?.Any(e => e.ClothingTypeId == id)).GetValueOrDefault();
        }
    }
}
