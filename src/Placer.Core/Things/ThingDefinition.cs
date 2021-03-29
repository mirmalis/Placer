using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placer.Core
{
  public class ThingDefinition : IDed
  {
    public Scope Scope { get; set; } public Guid ScopeID { get; set; }
    public string Name { get; set; }
    public ICollection<Thing> Things { get; set; }


    public ICollection<ThingDefinition_FieldDefinition> FieldDefinitionAssignments { get; set; }
    public ICollection<RelationDefinitionAssignment> RelationDefinitionAssignments { get; set; }
  }
}