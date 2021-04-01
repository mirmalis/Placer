using System;
using System.Collections.Generic;
namespace Placer.Core
{
  public class Scope : IDed
  {
    public Scope Parent { get; set; } public Guid? ParentID { get; set; } public ICollection<Scope> Children { get; set; }
    public string Name { get; set; }

    public ICollection<ThingDefinition> ThingDefinitions { get; set; }
    public ICollection<RelationDefinition> RelationDefinitions { get; set; }
    public ICollection<Idea> Ideas { get; set; }
  }
}
