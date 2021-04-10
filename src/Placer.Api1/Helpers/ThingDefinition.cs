using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Placer.Api1.Helpers.ThingDefinition
{
  public class Deep : Types.ThingDefinition.Deep
  {
    #region Constructors
    public Deep() { }
    public Deep(Guid? id, Core.ThingDefinition core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Name = core.Name;
      this.Scope = new ScopeLocation(new Scope.Shallow(core.ScopeID, core.Scope), core.ScopeLocation);
      this.Instances = core.Instances.Select(item => new Thing.Shallow(null, item) { Idea = new Idea.Shallow(item.IdeaID, item.Idea) });
      this.Scope = new ScopeLocation(new Scope.Shallow(core.ScopeID, core.Scope), core.ScopeLocation);
    }
    #endregion
    public static IQueryable<Core.ThingDefinition> Includes(IQueryable<Core.ThingDefinition> Q)
      => Q
      .Include(item => item.Instances).ThenInclude(item => item.Idea)
      
    ;
  }
  public class Shallow : Types.ThingDefinition.Shallow
  {
    #region Constructors
    public Shallow() { }
    public Shallow(Guid? id, Core.ThingDefinition core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Name = core.Name;

      this.Scope = new ScopeLocation(new Scope.Shallow(core.ScopeID, core.Scope), core.ScopeLocation);
    }
    #endregion
    public static IQueryable<Core.ThingDefinition> Includes(IQueryable<Core.ThingDefinition> Q)
      => Q
    ;
  }
}
