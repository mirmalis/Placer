using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Placer.Api1.Helpers.Idea
{
  public class Deep : Types.Idea.Deep
  {
    #region Constructors
    public Deep() { }
    public Deep(Guid? id, Core.Idea core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Name = core.Name;
      this.Things = core.Things.Select(item => new Thing.Shallow(null, item));
    }
    #endregion
    public static IQueryable<Core.Idea> Includes(IQueryable<Core.Idea> Q)
      => Q
      .Include(item => item.Things).ThenInclude(item => item.Definition)
    ;
  }
  public class Shallow : Types.Idea.Shallow
  {
    #region Constructors
    public Shallow() { }
    public Shallow(Guid? id, Core.Idea core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Name = core.Name;
    }
    #endregion
    public static IQueryable<Core.Idea> Includes(IQueryable<Core.Idea> Q)
      => Q
    ;
  }
}
