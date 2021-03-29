using System;

namespace Placer.Core
{
  public class FieldOfThing : IDed
  {
    public FieldDefinition Definition { get; set; } public Guid DefinitionID { get; set; }
    public Thing Thing { get; set; } public Guid ThingID { get; set; }
    public Value Value { get; set; } // Value is owned type, ValueID is not needed.
  }
}
