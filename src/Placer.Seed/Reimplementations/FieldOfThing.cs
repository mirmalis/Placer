using System;
using System.Collections.Generic;
using System.Text;

namespace Placer.Seed.Reimplementations
{
  class FieldOfThing : Core.FieldOfThing
  {
    #region Constructors
    public FieldOfThing() { }
    public FieldOfThing(Core.Thing thing, Core.FieldDefinition fieldDefinition, Core.Value value) : base()
    {
      this.Thing = thing;
      this.Definition = fieldDefinition;
      this.Value = value;
    }
    #endregion
  }
}
