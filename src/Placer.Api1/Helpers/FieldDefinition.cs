using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Placer.Api1.Helpers.FieldDefinition
{
  public class Deep : Types.FieldDefinition.Deep
  {
    #region Constructors
    public Deep() { }
    public Deep(Guid? id, Core.FieldDefinition core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
    }
    #endregion
    public static IQueryable<Core.FieldDefinition> Includes(IQueryable<Core.FieldDefinition> Q)
      => Q
    ;
  }
  public class Shallow : Types.FieldDefinition.Shallow
  {
    #region Constructors
    public Shallow() { }
    public Shallow(Guid? id, Core.FieldDefinition core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Name = core.Name;
    }
    #endregion
    public static IQueryable<Core.FieldDefinition> Includes(IQueryable<Core.FieldDefinition> Q)
      => Q
    ;
  }
}
