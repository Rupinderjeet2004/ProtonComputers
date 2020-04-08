using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtonComputers.Data;
using ProtonComputers.Models;

namespace ProtonComputers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManufacturersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturers>>> GetManufacturers()
        {
            return await _context.Manufacturers.ToListAsync();
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturers>> GetManufacturers(int id)
        {
            var manufacturers = await _context.Manufacturers.FindAsync(id);

            if (manufacturers == null)
            {
                return NotFound();
            }

            return manufacturers;
        }

        // PUT: api/Manufacturers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturers(int id, Manufacturers manufacturers)
        {
            if (id != manufacturers.ManufacturerID)
            {
                return BadRequest();
            }

            _context.Entry(manufacturers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturersExists(id))
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

        // POST: api/Manufacturers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Manufacturers>> PostManufacturers(Manufacturers manufacturers)
        {
            _context.Manufacturers.Add(manufacturers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacturers", new { id = manufacturers.ManufacturerID }, manufacturers);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Manufacturers>> DeleteManufacturers(int id)
        {
            var manufacturers = await _context.Manufacturers.FindAsync(id);
            if (manufacturers == null)
            {
                return NotFound();
            }

            _context.Manufacturers.Remove(manufacturers);
            await _context.SaveChangesAsync();

            return manufacturers;
        }

        private bool ManufacturersExists(int id)
        {
            return _context.Manufacturers.Any(e => e.ManufacturerID == id);
        }
    }
}
