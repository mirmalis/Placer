using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placer.Core
{
  public class RelationDefinition : IDed
  {
    public string Forward { get; set; }
    public string Backwards { get; set; }
    public ICollection<RelationDefinition_FieldDefinition> FieldDefinitionAssignments { get; set; }
    public ICollection<RelationDefinitionAssignment> AssignmentsToThingDefinitions { get; set; }
    public ICollection<Relation> Relations { get; set; }
  }
}