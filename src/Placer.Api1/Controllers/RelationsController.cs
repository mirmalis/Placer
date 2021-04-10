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
  public class RelationsController : ControllerBase
  {
    private readonly PlacerContext _context;

    public RelationsController(PlacerContext context)
    {
      _context = context;
    }

    // GET: api/Relations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Relation>>> GetRelations()
    {

      return await _context.Relations.ToListAsync();
    }


    [HttpGet("x/{fromID:guid?}")]
    [HttpGet("y/{definitionID:guid?}")]
    [HttpGet("z/{toID:guid?}")]
    [HttpGet("xy/{fromID:guid?}/{definitionID:guid?}")]
    [HttpGet("xz/{fromID:guid?}/{toID:guid?}")]
    [HttpGet("yz/{definitionID:guid?}/{toID:guid?}")]
    [HttpGet("xyz/{fromID:guid?}/{definitionID:guid?}/{toID:guid?}")]
    public async Task<ActionResult<IEnumerable<Types.Relation.Shallow>>> GetRelation(Guid? fromID, Guid? definitionID, Guid? toID)
    {
      return await Helpers.Relation.Shallow.Includes(_context.Relations)
        .Where(item =>
          (fromID == null || item.FromID == fromID) &&
          (definitionID == null || item.DefinitionID == definitionID) &&
          (toID == null || item.ToID == toID)
        )
        .Select(item => new Helpers.Relation.Shallow(null, item))
        .ToListAsync()
      ;
    }
    //// GET: api/Relations/5
    //[HttpGet("{id}")]
    //public async Task<ActionResult<Types.Relation.Deep>> GetRelation(Guid id)
    //{
    //  var relation = await Helpers.Relation.Deep.Includes(_context.Relations)
    //    .FirstOrDefaultAsync(item => item.ID == id)
    //  ;

    //  if (relation == null)
    //  {
    //    return NotFound();
    //  }

    //  return new Helpers.Relation.Deep(id, relation);
    //}

    // PUT: api/Relations/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRelation(Guid id, Relation relation)
    {
      if (id != relation.ID)
      {
        return BadRequest();
      }

      _context.Entry(relation).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RelationExists(id))
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

    // POST: api/Relations
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Relation>> PostRelation(Relation relation)
    {
      _context.Relations.Add(relation);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetRelation", new { id = relation.ID }, relation);
    }

    // DELETE: api/Relations/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRelation(Guid id)
    {
      var relation = await _context.Relations.FindAsync(id);
      if (relation == null)
      {
        return NotFound();
      }

      _context.Relations.Remove(relation);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool RelationExists(Guid id)
    {
      return _context.Relations.Any(e => e.ID == id);
    }
  }
}
