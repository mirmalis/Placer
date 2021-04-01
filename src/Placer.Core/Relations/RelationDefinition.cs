using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placer.Core
{
  public class RelationDefinition : IDed, IDefinition<Relation>
  {
    public Scope Scope { get; set; } public Guid ScopeID { get; set; }
    public ScopeLocation ScopeLocation { get; set; }
    public string Forward { get; set; }
    public string Backwards { get; set; }

    public ICollection<FieldDefinitionAssignment<RelationDefinition>> FieldDefinitionAssignments { get; set; }

    public ICollection<Relation> Instances { get; set; }
  }
}