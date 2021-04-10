using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Placer.Api1.Helpers.Thing
{
  public class Deep : Types.Thing.Deep
  {
    #region Constructors
    public Deep() { }
    public Deep(Guid? id, Core.Thing core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Definition = new ThingDefinition.Shallow(core.DefinitionID, core.Definition);
      this.Idea = new Idea.Shallow(core.IdeaID, core.Idea);
      this.Fields = core.FieldInstances
        .Where(item => (item.Definition.DataType != Core.Value.DataType.Flag) 
                    || (item.Definition.DataType == Core.Value.DataType.Flag && item.Value.Integer > 0)
        )
        .Select(item =>
          new Types.Field.Deep<Types.Thing.Deep>() { 
            ID = item.ID,
            FieldDefinition = new FieldDefinition.Shallow(item.DefinitionID, item.Definition), 
            String = item.Value.ToString(),
            Data = item.Value.Data
          }
        )
      ;
      //this.RelationsFrom = core.RelationsFrom.Select(item => new Relation.Deep(null, item));
      //this.RelationsTo = core.RelationsTo.Select(item => new Relation.Deep(null, item));
      this.Start = core.Start;
      this.End = core.End;
    }
    #endregion
    public static IQueryable<Core.Thing> Includes(IQueryable<Core.Thing> Q)
      => Q
      .Include(item => item.Idea)
      .Include(item => item.Definition)
      .Include(item => item.FieldInstances).ThenInclude(item => item.Definition)
      .Include(item => item.RelationsFrom).ThenInclude(item => item.Definition)
      .Include(item => item.RelationsFrom).ThenInclude(item => item.FieldInstances).ThenInclude(item => item.Definition)
      .Include(item => item.RelationsFrom).ThenInclude(item => item.To).ThenInclude(item => item.Definition)
      .Include(item => item.RelationsTo).ThenInclude(item => item.Definition)
      .Include(item => item.RelationsTo).ThenInclude(item => item.FieldInstances).ThenInclude(item => item.Definition)
      .Include(item => item.RelationsTo).ThenInclude(item => item.From).ThenInclude(item => item.Definition)
    ;
  }
  public class Shallow : Types.Thing.Shallow
  {
    #region Constructors
    public Shallow() { }
    public Shallow(Guid? id, Core.Thing core) : base()
    {
      this.ID = Calc.ID(id, core);
      if (core == null)
        return;
      this.Definition = new ThingDefinition.Shallow(core.DefinitionID, core.Definition);
      this.Idea = new Idea.Shallow(core.IdeaID, core.Idea);
      this.Start = core.Start;
      this.End = core.End;
    }
    #endregion
    public static IQueryable<Core.Thing> Includes(IQueryable<Core.Thing> Q)
      => Q
      .Include(item => item.Idea)
    ;
  }
}

