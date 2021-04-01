using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core
{
  public class FieldDefinitionAssignment<TTo> : IDed
    where TTo: IDefinition
  {
    public TTo Definition { get; set; } public Guid DefinitionID { get; set; }
    public FieldDefinition FieldDefinition { get; set; } public Guid FieldDefinitionID { get; set; }
  }
}
