using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placer.Seed.Reimplementations
{
  class Thing : Core.Thing
  {
    #region Constructors
    public Thing() { }
    public Thing(Core.ThingDefinition definition, Core.Idea idea = null) : base()
    {
      this.Definition = definition;
      this.Idea = idea ?? new Core.Idea();
    }
    public Thing(Core.ThingDefinition definition, string name) : this(definition, new Idea(name))
    {
    }
    #endregion
    public Thing AddRelationFrom(Core.RelationDefinition relationDefinition, Thing to)
    {
      this.RelationsFrom ??= new List<Core.Relation>();
      var result = new Relation(this, relationDefinition, to);
      this.RelationsFrom.Add(result);
      return this;
    }
    public Thing AddRelationTo(Core.RelationDefinition relationDefinition, Thing from)
    {
      this.RelationsTo ??= new List<Core.Relation>();
      var result = new Relation(from, relationDefinition, this);
      this.RelationsTo.Add(result);
      return this;
    }
    public Thing AddValue(Core.FieldDefinition fieldDefinition, Core.Value value)
    {
      this.FieldInstances ??= new List<Core.Field<Core.Thing>>();
      var result = new FieldOfThing(this, fieldDefinition, value);
      this.FieldInstances.Add(result);
      return this;
    }
    public Relation LastRelationFrom => (Relation)this.RelationsFrom.Last();
    
  }
}
