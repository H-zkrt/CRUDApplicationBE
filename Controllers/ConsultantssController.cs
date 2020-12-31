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
    public class ConsultantssController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ConsultantssController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Consultantss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultant>>> GetConsultants()
        {
            return await _context.Consultants.ToListAsync();
        }

        // GET: api/Consultantss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultant>> GetConsultant(int id)
        {
            var consultant = await _context.Consultants.FindAsync(id);

            if (consultant == null)
            {
                return NotFound();
            }

            return consultant;
        }

        // PUT: api/Consultantss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultant(int id, Consultant consultant)
        {
            if (id != consultant.CId)
            {
                return BadRequest();
            }

            _context.Entry(consultant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantExists(id))
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

        // POST: api/Consultantss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consultant>> PostConsultant(Consultant consultant)
        {
            _context.Consultants.Add(consultant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultant", new { id = consultant.CId }, consultant);
        }

        // DELETE: api/Consultantss/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultant(int id)
        {
            var consultant = await _context.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            _context.Consultants.Remove(consultant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultantExists(int id)
        {
            return _context.Consultants.Any(e => e.CId == id);
        }
    }
}
