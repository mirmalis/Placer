using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placer.Core
{
  public class FieldDefinition : IDed
  {
    public string Name { get; set; }
    public Value.DataType DataType { get; set; }
    //public ICollection<Definition_FieldDefinition<TDefinition>> ThingDefinition_FieldDefinition { get; set; }
  }
}