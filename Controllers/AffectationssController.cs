using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDApplication.Data;
using CRUDApplication.Models;

namespace CRUDApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffectationssController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public AffectationssController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Affectationss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Affectation>>> GetAffecations()
        {
            return await _context.Affecations.ToListAsync();
        }

        // GET: api/Affectationss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Affectation>> GetAffectation(int id)
        {
            var affectation = await _context.Affecations.FindAsync(id);

            if (affectation == null)
            {
                return NotFound();
            }

            return affectation;
        }

        // PUT: api/Affectationss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAffectation(int id, Affectation affectation)
        {
            if (id != affectation.AId)
            {
                return BadRequest();
            }

            _context.Entry(affectation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AffectationExists(id))
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

        // POST: api/Affectationss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Affectation>> PostAffectation(Affectation affectation)
        {
            _context.Affecations.Add(affectation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAffectation", new { id = affectation.AId }, affectation);
        }

        // DELETE: api/Affectationss/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAffectation(int id)
        {
            var affectation = await _context.Affecations.FindAsync(id);
            if (affectation == null)
            {
                return NotFound();
            }

            _context.Affecations.Remove(affectation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AffectationExists(int id)
        {
            return _context.Affecations.Any(e => e.AId == id);
        }
    }
}
