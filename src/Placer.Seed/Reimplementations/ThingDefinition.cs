using System;
using System.Collections.Generic;
using System.Linq;

namespace Placer.Seed.Reimplementations
{
  class ThingDefinition : Core.ThingDefinition
  {
    #region Constructors
    public ThingDefinition() { }
    public ThingDefinition(Scope scope, string name) : base()
    {
      this.Scope = scope;
      this.Name = name;
    }
    #endregion
    public ThingDefinition AddFieldDefinition(Core.FieldDefinition fieldDefinition)
    {
      this.FieldDefinitionAssignments ??= new List<Core.ThingDefinition_FieldDefinition>();
      var result = new Core.ThingDefinition_FieldDefinition() {
        Definition = this,
        FieldDefinition = fieldDefinition
      };
      this.FieldDefinitionAssignments.Add(result);
      return this;
    }
    public ThingDefinition AddRelationDefinition(Core.RelationDefinition relationDefinition)
    {
      this.RelationDefinitionAssignments ??= new List<Core.RelationDefinitionAssignment>();
      var result = new Core.RelationDefinitionAssignment()
      {
        ThingDefinition = this,
        RelationDefinition = relationDefinition
      };
      this.RelationDefinitionAssignments.Add(result);
      return this;
    }
    public ThingDefinition AddInstances(params Core.Idea[] ideas)
    {
      this.Things ??= new List<Core.Thing>();
      foreach (var thing in ideas.Select(idea => (Core.Thing)new Thing(this, idea)))
      {
        this.Things.Add(thing);
      }
      return this;
    }
  }
}
