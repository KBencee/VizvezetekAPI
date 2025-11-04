using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VizvezetekWebAPI.Data;
using VizvezetekWebAPI.Models;

namespace VizvezetekWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SzereloController : Controller
    {
        private readonly SzereloDbContext _context;
        public SzereloController(SzereloDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Szerelo>>> GetSzerelok()
        {
            return await _context.Szerelok.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Szerelo>> GetSzerelo(int id)
        {
            var szerelo = await _context.Szerelok.FindAsync(id);
            if (szerelo == null)
            {
                return NotFound();
            }
            return szerelo;
        }

        [HttpPost]
        public async Task<ActionResult<Szerelo>> CreateSzerelo(Szerelo szerelo)
        {
            _context.Szerelok.Add(szerelo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSzerelok), new { id = szerelo.Az }, szerelo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSzerelo(int id)
        {
            var szerelo = await _context.Szerelok.FindAsync(id);
            if (szerelo == null)
            {
                return NotFound();
            }
            _context.Szerelok.Remove(szerelo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSzerelo(int id, Szerelo updatedSzerelo)
        {
            if (id != updatedSzerelo.Az)
            {
                return BadRequest();
            }
            var szerelo = await _context.Szerelok.FindAsync(id);
            if (szerelo == null)
            {
                return NotFound();
            }
            szerelo.Nev = updatedSzerelo.Nev;
            szerelo.KezdEv = updatedSzerelo.KezdEv;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
