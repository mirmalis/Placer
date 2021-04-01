using System;
using System.Collections.Generic;
using System.Linq;
namespace Placer.Core
{
  public class Relation : IDed, IInstance<RelationDefinition>
  {
    public RelationDefinition Definition { get; set; } public Guid DefinitionID { get; set; }
    public Thing From { get; set; } public Guid FromID { get; set; }
    public Thing To { get; set; } public Guid ToID { get; set; }

    public ICollection<Field<Relation>> FieldInstances { get; set; }
  }
}