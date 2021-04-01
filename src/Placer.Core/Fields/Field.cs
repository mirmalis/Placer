using System;

namespace Placer.Core
{
  public class Field<TInstance> : IDed
    where TInstance: IInstance
  {
    public TInstance Instance { get; set; } public Guid InstanceID { get; set; }
    public FieldDefinition Definition { get; set; } public Guid DefinitionID { get; set; }
    public Value Value { get; set; } // Value is owned type, ValueID is not needed.
  }
}
