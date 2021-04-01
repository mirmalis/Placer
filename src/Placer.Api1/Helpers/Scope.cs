using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Placer.Api1.Helpers.Scope
{
  public class Deep : Types.Scope.Deep
  {
    public Deep(Guid? id, Core.Scope core)
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Name = core.Name;
      this.Children = core.Children.Select(item => new Shallow(null, item));
      this.ThingDefinitions = core.ThingDefinitions.Select(item => new ThingDefinition.Shallow(null, item));
      if (core.ParentID != null)
      {
        this.Parent = new Types.IDed(core.ParentID.Value);
      }
    }
    public static IQueryable<Core.Scope> Includes(IQueryable<Core.Scope> Q)
      => Q
      .Include(item => item.ThingDefinitions)
    ;

  }
  public class Shallow : Types.Scope.Shallow
  {
    public Shallow(Guid? id, Core.Scope core)
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Name = core.Name;

      if (core.ParentID != null)
      {
        this.Parent = new Types.IDed(core.ParentID.Value);
      }
    }
    public static IQueryable<Core.Scope> Includes(IQueryable<Core.Scope> Q)
      => Q
    ;
  }
}
