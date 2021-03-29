using System;
using System.Collections.Generic;
using System.Linq;
namespace Placer.Core
{
  public class Relation : IDed
  {
    public Thing From { get; set; } public Guid FromID { get; set; }
    public Thing To { get; set; } public Guid ToID { get; set; }

    public RelationDefinition RelationDefinition { get; set; } public Guid? RelationDefinitionID { get; set; }
    public ICollection<FieldOfRelation> FieldInstances { get; set; }
  }
}