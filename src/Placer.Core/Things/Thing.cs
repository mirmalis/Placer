using System;
using System.Collections.Generic;
using System.Linq;

namespace Placer.Core
{
  public class Thing : IDed, IInstance<ThingDefinition>
  {
    public Idea Idea { get; set; } public Guid IdeaID { get; set; }
    public ThingDefinition Definition { get; set; } public Guid DefinitionID { get; set; }

    public ICollection<Field<Thing>> FieldInstances { get; set; }
    public ICollection<Relation> RelationsFrom { get; set; }
    public ICollection<Relation> RelationsTo { get; set; }
  }
}