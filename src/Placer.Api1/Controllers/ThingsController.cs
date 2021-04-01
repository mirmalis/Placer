using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Placer.Core;
using Placer.Db;

namespace Placer.Api1.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ThingsController : ControllerBase
  {
    private readonly PlacerContext _context;

    public ThingsController(PlacerContext context)
    {
      _context = context;
    }

    // TODO: comment
    // GET: api/Things
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Thing>>> GetThings()
    {
      return await _context.Things.ToListAsync();
    }

    // GET: api/Things/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Types.Thing.Deep>> GetThing(Guid id)
    {
      
      var thing = await Helpers.Thing.Deep.Includes(_context.Things)
        .FirstOrDefaultAsync(item => item.ID == id);

      if (thing == null)
      {
        return NotFound();
      }

      return new Helpers.Thing.Deep(id, thing);
    }

    // PUT: api/Things/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutThing(Guid id, Thing thing)
    {
      if (id != thing.ID)
      {
        return BadRequest();
      }

      _context.Entry(thing).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ThingExists(id))
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

    // POST: api/Things
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Thing>> PostThing(Thing thing)
    {
      _context.Things.Add(thing);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetThing", new { id = thing.ID }, thing);
    }

    // DELETE: api/Things/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteThing(Guid id)
    {
      var thing = await _context.Things.FindAsync(id);
      if (thing == null)
      {
        return NotFound();
      }

      _context.Things.Remove(thing);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool ThingExists(Guid id)
    {
      return _context.Things.Any(e => e.ID == id);
    }
  }
}
