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
  public class ThingDefinitionsController : ControllerBase
  {
    private readonly PlacerContext _context;

    public ThingDefinitionsController(PlacerContext context)
    {
      _context = context;
    }

    //// GET: api/ThingDefinitions
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<ThingDefinition>>> GetThingDefinitions()
    //{
    //  return await _context.ThingDefinitions.ToListAsync();
    //}

    // GET: api/ThingDefinitions/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Types.ThingDefinition.Deep>> GetThingDefinition(Guid id)
    {
      var thingDefinition = await Helpers.ThingDefinition.Deep.Includes(_context.ThingDefinitions)
        .FirstOrDefaultAsync(item => item.ID == id);

      if (thingDefinition == null)
      {
        return NotFound();
      }

      return new Helpers.ThingDefinition.Deep(id, thingDefinition);
    }

    // PUT: api/ThingDefinitions/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutThingDefinition(Guid id, ThingDefinition thingDefinition)
    {
      if (id != thingDefinition.ID)
      {
        return BadRequest();
      }

      _context.Entry(thingDefinition).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ThingDefinitionExists(id))
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

    // POST: api/ThingDefinitions
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ThingDefinition>> PostThingDefinition(ThingDefinition thingDefinition)
    {
      _context.ThingDefinitions.Add(thingDefinition);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetThingDefinition", new { id = thingDefinition.ID }, thingDefinition);
    }

    // DELETE: api/ThingDefinitions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteThingDefinition(Guid id)
    {
      var thingDefinition = await _context.ThingDefinitions.FindAsync(id);
      if (thingDefinition == null)
      {
        return NotFound();
      }

      _context.ThingDefinitions.Remove(thingDefinition);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool ThingDefinitionExists(Guid id)
    {
      return _context.ThingDefinitions.Any(e => e.ID == id);
    }
  }
}
