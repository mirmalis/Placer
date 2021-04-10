using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core
{
  public class RelationDefinitionRestriction : IDed
  {
    public enum RestrictionType { Allow, Require, Forbid }
    public RelationDefinition RelationDefinition { get; set; } public Guid RelationDefinitionID { get; set; }
    public RestrictionType Type { get; set; }

    public ICollection<RelationDefinitionRestrictionFrom> FromThingTypes { get; set; }
    public ICollection<RelationDefinitionRestrictionTo> ToThingTypes { get; set; }
  }
}
