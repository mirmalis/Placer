using System;
using System.Collections.Generic;
using System.Text;

namespace Placer.Seed.Reimplementations
{
  class Relation : Core.Relation
  {
    #region Constructors
    public Relation() { }
    public Relation(Core.Thing from, Core.RelationDefinition definition, Core.Thing to) : base()
    {
      base.From = from;
      this.Definition = definition;
      base.To = to;
    }
    #endregion
    public Relation AddValue(Core.FieldDefinition fieldDefinition, Core.Value value)
    {
      this.FieldInstances ??= new List<Core.Field<Core.Relation>>();
      var result = new Core.Field<Core.Relation>() { Instance = this, Definition = fieldDefinition, Value = value };
      this.FieldInstances.Add(result);
      return this;
    }
    public new Thing From =>  (Thing)base.From;
    public new Thing To => (Thing)base.To;
  }
}
