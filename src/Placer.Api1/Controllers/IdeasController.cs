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
  public class IdeasController : ControllerBase
  {
    private readonly PlacerContext _context;

    public IdeasController(PlacerContext context)
    {
      _context = context;
    }

    //// GET: api/Ideas
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Idea>>> GetIdeas()
    //{
    //  return await _context.Ideas.ToListAsync();
    //}

    // GET: api/Ideas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Types.Idea.Deep>> GetIdea(Guid id)
    {
      var idea = await Helpers.Idea.Deep.Includes(_context.Ideas)
        .FirstOrDefaultAsync(item => item.ID == id);

      if (idea == null)
      {
        return NotFound();
      }

      return new Helpers.Idea.Deep(id, idea);
    }

    // PUT: api/Ideas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutIdea(Guid id, Idea idea)
    {
      if (id != idea.ID)
      {
        return BadRequest();
      }

      _context.Entry(idea).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!IdeaExists(id))
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

    // POST: api/Ideas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Idea>> PostIdea(Idea idea)
    {
      _context.Ideas.Add(idea);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetIdea", new { id = idea.ID }, idea);
    }

    // DELETE: api/Ideas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIdea(Guid id)
    {
      var idea = await _context.Ideas.FindAsync(id);
      if (idea == null)
      {
        return NotFound();
      }

      _context.Ideas.Remove(idea);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool IdeaExists(Guid id)
    {
      return _context.Ideas.Any(e => e.ID == id);
    }
  }
}
