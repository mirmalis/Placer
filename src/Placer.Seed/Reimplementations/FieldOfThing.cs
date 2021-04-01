using System;
using System.Collections.Generic;
using System.Text;

namespace Placer.Seed.Reimplementations
{
  class FieldOfThing : Core.Field<Core.Thing>
  {
    #region Constructors
    public FieldOfThing() { }
    public FieldOfThing(Core.Thing thing, Core.FieldDefinition fieldDefinition, Core.Value value) : base()
    {
      this.Instance = thing;
      this.Definition = fieldDefinition;
      this.Value = value;
    }
    #endregion
  }
}
