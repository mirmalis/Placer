using System;
using System.Collections.Generic;
using System.Text;

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
