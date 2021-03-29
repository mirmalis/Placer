using System;

namespace Placer.Core
{
  public class FieldOfRelation : IDed
  {
    public FieldDefinition Definition { get; set; } public Guid DefinitionID { get; set; }
    public Relation Relation { get; set; } public Guid RelationID { get; set; }
    public Value Value { get; set; } // Value is owned type, ValueID is not needed.
  }
}
