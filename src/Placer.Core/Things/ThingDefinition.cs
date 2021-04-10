using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placer.Core
{
  public class ThingDefinition : IDed, IDefinition<Thing>
  {
    public Scope Scope { get; set; } public Guid ScopeID { get; set; }
    public ScopeLocation ScopeLocation { get; set; }
    public string Name { get; set; }
    public ICollection<FieldDefinitionAssignment<ThingDefinition>> FieldDefinitionAssignments { get; set; }

    public ICollection<Thing> Instances { get; set; }
    public ICollection<Format> Formats { get; set; }

    public ICollection<RelationDefinitionRestrictionFrom> RelationDefinitionRestrictionsFrom { get; set; }
    public ICollection<RelationDefinitionRestrictionTo> RelationDefinitionRestrictionsTo { get; set; }
  }
}
