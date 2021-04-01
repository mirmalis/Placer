using System;
using System.Collections.Generic;

namespace Placer.Api1.Types.Thing
{
  public interface I : IIDed<Guid>
  {
    public Idea.Shallow Idea { get; set; }
    public ThingDefinition.Shallow Definition { get; set; }
  }
  public class Deep : I
  {
    public Guid ID { get; set; }
    public Idea.Shallow Idea { get; set; }
    public ThingDefinition.Shallow Definition { get; set; }

    public IEnumerable<Field.Deep<Deep>> Fields { get; set; }
    public IEnumerable<Relation.Deep> RelationsFrom { get; set; }
    public IEnumerable<Relation.Deep> RelationsTo { get; set; }
  }
  public class Shallow : I
  {
    public Guid ID { get; set; }
    public Idea.Shallow Idea { get; set; }
    public ThingDefinition.Shallow Definition { get; set; }
  }
}