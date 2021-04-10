using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placer.Core
{
  public interface IRelationDefinitionRestrictionX
  {
    public RelationDefinitionRestriction RelationDefinitionRestriction { get; set; } public Guid RelationDefinitionRestrictionID { get; set; }
  }
  public class RelationDefinitionRestrictionFrom : IDed, IRelationDefinitionRestrictionX
  {
    public RelationDefinitionRestriction RelationDefinitionRestriction { get; set; } public Guid RelationDefinitionRestrictionID { get; set; }
    public ThingDefinition ThingDefinition { get; set; } public Guid ThingDefinitionID { get; set; }
  }
  public class RelationDefinitionRestrictionTo : IDed
  {
    public RelationDefinitionRestriction RelationDefinitionRestriction { get; set; } public Guid RelationDefinitionRestrictionID { get; set; }
    public ThingDefinition ThingDefinition { get; set; } public Guid ThingDefinitionID { get; set; }
  }
}
