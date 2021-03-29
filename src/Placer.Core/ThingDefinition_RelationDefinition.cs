using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placer.Core
{
  public class RelationDefinitionAssignment : IDed
  {
    public RelationDefinition RelationDefinition { get; set; } public Guid RelationDefinitionID { get; set; }
    public ThingDefinition ThingDefinition { get; set; } public Guid ThingDefinitionID { get; set; }
  }
}