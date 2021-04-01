using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Placer.Api1.Helpers.Field
{
  public class Deep<TInstance> : Types.Field.Deep<TInstance>
    where TInstance : Core.IInstance
  {
    #region Constructors
    public Deep() { }
    public Deep(Guid? id, Core.Field<TInstance> core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
    }
    #endregion
    public static IQueryable<Core.Field<TInstance>> Includes(IQueryable<Core.Field<TInstance>> Q)
      => Q
    ;
  }
  public class Shallow<TInstance> : Types.Field.Shallow<TInstance>
    where TInstance : Core.IInstance
  {
    #region Constructors
    public Shallow() { }
    public Shallow(Guid? id, Core.Field<TInstance> core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
    }
    #endregion
    public static IQueryable<Core.Field<TInstance>> Includes(IQueryable<Core.Field<TInstance>> Q)
      => Q
    ;
  }
}
