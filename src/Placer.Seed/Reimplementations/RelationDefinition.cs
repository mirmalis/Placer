using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Placer.Seed.Reimplementations
{
  class RelationDefinition : Core.RelationDefinition
  {
    #region Constructors
    public RelationDefinition() { }
    public RelationDefinition(Core.Scope scope, string forwards, string backwards, int x = 0, int y = 0, int z = 0) : base()
    {
      this.Scope = scope;
      this.ScopeLocation = new Core.ScopeLocation(x, y, z);
      this.Forward = forwards;
      this.Backwards = backwards;
    }
    #endregion
    public RelationDefinition AddRestriction(Core.RelationDefinitionRestriction.RestrictionType type, Core.ThingDefinition from, Core.ThingDefinition to)
    {
      return AddRestriction(
        type,
        new List<Core.ThingDefinition>() { from },
        new List<Core.ThingDefinition>() { to }
      );
    }
    public RelationDefinition AddRestriction(Core.RelationDefinitionRestriction.RestrictionType type, IEnumerable<Core.ThingDefinition> froms, IEnumerable<Core.ThingDefinition> tos)
    {
      this.RelationDefinitionRestrictions ??= new List<Core.RelationDefinitionRestriction>();
      ;
      var result = new Core.RelationDefinitionRestriction()
      {
        FromThingTypes = froms.Select(item => new Core.RelationDefinitionRestrictionFrom() { ThingDefinition = item }).ToList(),
        ToThingTypes = froms.Select(item => new Core.RelationDefinitionRestrictionTo() { ThingDefinition = item }).ToList(),
        Type = type
      };
      return this;
    }
    public RelationDefinition AddFieldDefinition(Core.FieldDefinition fieldDefinition)
    {
      this.FieldDefinitionAssignments ??= new List<Core.FieldDefinitionAssignment<Core.RelationDefinition>>();
      var result = new Core.FieldDefinitionAssignment<Core.RelationDefinition>()
      {
        Definition = this,
        FieldDefinition = fieldDefinition
      };
      this.FieldDefinitionAssignments.Add(result);
      return this;
    }

  }
}
