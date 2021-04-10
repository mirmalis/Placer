using System;

namespace Placer.Core
{
  public class FormatPart : IDed
  {
    public int Order { get; set; }
    public FieldDefinition FieldDefinition { get; set; } public Guid FieldDefinitionID { get; set; }
  }
}
