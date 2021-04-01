using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Placer.Api1.Helpers.RelationDefinition
{
  public class Deep : Types.RelationDefinition.Deep
  {
    #region Constructors
    public Deep() { }
    public Deep(Guid? id, Core.RelationDefinition core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Forward = core.Forward;
      this.Backward = core.Backwards;
    }
    #endregion
    public static IQueryable<Core.RelationDefinition> Includes(IQueryable<Core.RelationDefinition> Q)
      => Q
    ;
  }
  public class Shallow : Types.RelationDefinition.Shallow
  {
    #region Constructors
    public Shallow() { }
    public Shallow(Guid? id, Core.RelationDefinition core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Forward = core.Forward;
      this.Backward = core.Backwards;
    }
    #endregion
    public static IQueryable<Core.RelationDefinition> Includes(IQueryable<Core.RelationDefinition> Q)
      => Q
    ;
  }
}
