using System;
using System.Collections.Generic;
using System.Linq;

namespace Placer.Seed.Reimplementations
{
  class ThingDefinition : Core.ThingDefinition
  {
    #region Constructors
    public ThingDefinition() { }
    public ThingDefinition(Scope scope, string name, int x = 0, int y = 0, int z = 0) : base()
    {
      this.Scope = scope;
      this.ScopeLocation = new Core.ScopeLocation(x, y, z);

      this.Name = name;
    }
    #endregion
    public ThingDefinition AddFieldDefinition(Core.FieldDefinition fieldDefinition)
    {
      this.FieldDefinitionAssignments ??= new List<Core.FieldDefinitionAssignment<Core.ThingDefinition>>();
      var result = new Core.FieldDefinitionAssignment<Core.ThingDefinition>()
      {
        Definition = this,
        FieldDefinition = fieldDefinition
      };
      this.FieldDefinitionAssignments.Add(result);
      return this;
    }
    public ThingDefinition AddInstances(params Core.Idea[] ideas)
    {
      this.Instances ??= new List<Core.Thing>();
      foreach (var thing in ideas.Select(idea => (Core.Thing)new Thing(this, idea)))
      {
        this.Instances.Add(thing);
      }
      return this;
    }
  }
}
