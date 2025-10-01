using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HiddenLotus.Data;

namespace HiddenLotus
{
    [Route("api/[controller]")]
    [ApiController]
    public class FighterController : ControllerBase
    {
        private readonly HiddenLotusContext _context;

        public FighterController(HiddenLotusContext context)
        {
            _context = context;
        }

        // GET: api/Fighter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fighter>>> GetFighter()
        {
            return await _context.Fighter.ToListAsync();
        }

        // GET: api/Fighter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fighter>> GetFighter(int id)
        {
            var fighter = await _context.Fighter.FindAsync(id);

            if (fighter == null)
            {
                return NotFound();
            }

            return fighter;
        }

        // PUT: api/Fighter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFighter(int id, Fighter fighter)
        {
            if (id != fighter.Id)
            {
                return BadRequest();
            }

            _context.Entry(fighter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FighterExists(id))
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

        // POST: api/Fighter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fighter>> PostFighter(Fighter fighter)
        {
            _context.Fighter.Add(fighter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFighter", new { id = fighter.Id }, fighter);
        }

        // DELETE: api/Fighter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFighter(int id)
        {
            var fighter = await _context.Fighter.FindAsync(id);
            if (fighter == null)
            {
                return NotFound();
            }

            _context.Fighter.Remove(fighter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FighterExists(int id)
        {
            return _context.Fighter.Any(e => e.Id == id);
        }
    }
}
