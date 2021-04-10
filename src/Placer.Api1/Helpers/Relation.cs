using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Placer.Api1.Helpers.Relation
{
  public class Deep : Types.Relation.Deep
  {
    #region Constructors
    public Deep() { }
    public Deep(Guid? id, Core.Relation core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Definition = new RelationDefinition.Shallow(core.DefinitionID, core.Definition);
      this.From = new Thing.Shallow(core.FromID, core.From);
      this.To = new Thing.Shallow(core.ToID, core.To);
      this.Fields = core.FieldInstances.Select(item => new Types.Field.Deep<Types.Relation.Deep>() {
        ID = item.ID,
        String = item.Value.ToString(),
        Data = item.Value.Data,
        Instance = null, // TODO: 
        FieldDefinition = new FieldDefinition.Shallow(item.DefinitionID, item.Definition),
      });
    }
    #endregion
    public static IQueryable<Core.Relation> Includes(IQueryable<Core.Relation> Q)
      => Q
      .Include(item => item.Definition)
      .Include(item => item.From).ThenInclude(item => item.Idea)
      .Include(item => item.To).ThenInclude(item => item.Idea)
    ;
  }
  public class Shallow : Types.Relation.Shallow
  {
    #region Constructors
    public Shallow() { }
    public Shallow(Guid? id, Core.Relation core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Definition = new RelationDefinition.Shallow(core.DefinitionID, core.Definition);
      this.From = new Thing.Shallow(core.FromID, core.From);
      this.To = new Thing.Shallow(core.ToID, core.To);
    }
    #endregion
    public static IQueryable<Core.Relation> Includes(IQueryable<Core.Relation> Q)
      => Q
      .Include(item => item.Definition)
      .Include(item => item.From).ThenInclude(item => item.Idea)
      .Include(item => item.From).ThenInclude(item => item.Definition)
      .Include(item => item.To).ThenInclude(item => item.Idea)
      .Include(item => item.To).ThenInclude(item => item.Definition)
    ;
  }
}
