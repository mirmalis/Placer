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
  public class ScopesController : ControllerBase
  {
    private readonly PlacerContext _context;

    public ScopesController(PlacerContext context)
    {
      _context = context;
    }

    // GET: api/Scopes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Api1.Types.Scope.Shallow>>> GetScopes()
    {
      return await Helpers.Scope.Shallow.Includes(_context.Scopes)
        .Where(item => item.ParentID == null)
        .Select(item => new Helpers.Scope.Shallow(null, item))
        .ToListAsync();
    }

    // GET: api/Scopes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Types.Scope.Deep>> GetScope(Guid id)
    {
      var scope = await Helpers.Scope.Deep.Includes(_context.Scopes)
        .Include(item => item.Children)
        .FirstOrDefaultAsync(item => item.ID == id);

      if (scope == null)
        return NotFound();

      return new Helpers.Scope.Deep(id, scope);
    }

    // PUT: api/Scopes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutScope(Guid id, Scope scope)
    {
      if (id != scope.ID)
      {
        return BadRequest();
      }

      _context.Entry(scope).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ScopeExists(id))
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

    // POST: api/Scopes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Scope>> PostScope(Types.Scope.Shallow scope)
    {
      _context.Scopes.Add(new Core.Scope() { ID = scope.ID, Name = scope.Name });
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetScope", new { id = scope.ID }, scope);
    }

    // DELETE: api/Scopes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScope(Guid id)
    {
      var scope = await _context.Scopes.FindAsync(id);
      if (scope == null)
      {
        return NotFound();
      }

      _context.Scopes.Remove(scope);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool ScopeExists(Guid id)
    {
      return _context.Scopes.Any(e => e.ID == id);
    }
  }
}
