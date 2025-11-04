using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VizvezetekWebAPI.Data;
using VizvezetekWebAPI.Models;

namespace VizvezetekWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelyController : Controller
    {
        private readonly SzereloDbContext _context;
        public HelyController(SzereloDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hely>>> GetHelyek()
        {
            var helyek = await _context.Helyek.ToListAsync();
            return Ok(helyek);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hely>> GetHely(int id)
        {
            var hely = await _context.Helyek.FindAsync(id);
            if (hely == null)
            {
                return NotFound();
            }
            return Ok(hely);
        }

        [HttpPost]
        public async Task<ActionResult<Hely>> CreateHely(Hely hely)
        {
            _context.Helyek.Add(hely);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHely), new { id = hely.Az }, hely);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHely(int id)
        {
            var hely = await _context.Helyek.FindAsync(id);
            if (hely == null)
            {
                return NotFound();
            }
            _context.Helyek.Remove(hely);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateHely(int id, Hely updatedHely)
        {
            if (id != updatedHely.Az)
            {
                return BadRequest();
            }
            var hely = await _context.Helyek.FindAsync(id);
            if (hely == null)
            {
                return NotFound();
            }
            hely.Telepules = updatedHely.Telepules;
            hely.Utca = updatedHely.Utca;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
