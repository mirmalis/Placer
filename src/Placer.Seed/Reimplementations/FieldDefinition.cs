using System;
using System.Collections.Generic;
using System.Text;

namespace Placer.Seed.Reimplementations
{
  class FieldDefinition : Core.FieldDefinition
  {
    #region Constructors
    public FieldDefinition() { }
    public FieldDefinition(string name, Core.Value.DataType dataType) : base()
    {
      this.Name = name;
      this.DataType = dataType;
    }
    #endregion
  }
}
