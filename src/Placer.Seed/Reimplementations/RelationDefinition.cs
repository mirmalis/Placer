using System;
using System.Collections.Generic;
using System.Text;

namespace Placer.Seed.Reimplementations
{
  class RelationDefinition : Core.RelationDefinition
  {
    #region Constructors
    public RelationDefinition() { }
    public RelationDefinition(string forwards, string backwards) : base()
    {
      this.Forward = forwards;
      this.Backwards = backwards;
    }
    #endregion
    public RelationDefinition AddFieldDefinition(Core.FieldDefinition fieldDefinition)
    {
      this.FieldDefinitionAssignments ??= new List<Core.RelationDefinition_FieldDefinition>();
      var result = new Core.RelationDefinition_FieldDefinition()
      {
        Definition = this,
        FieldDefinition = fieldDefinition
      };
      this.FieldDefinitionAssignments.Add(result);
      return this;
    }

  }
}
