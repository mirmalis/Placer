using System;
using System.Collections.Generic;

namespace Placer.Api1.Types.Thing
{
  public interface I : IIDed<Guid>
  {
    public Idea.Shallow Idea { get; set; }
    public ThingDefinition.Shallow Definition { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
  }
  public class Deep : I
  {
    public Guid ID { get; set; }
    public Idea.Shallow Idea { get; set; }
    public ThingDefinition.Shallow Definition { get; set; }

    public IEnumerable<Field.Deep<Deep>> Fields { get; set; }
    //public IEnumerable<IIDed<Guid>> RelationsFrom { get; set; }
    //public IEnumerable<IIDed<Guid>> RelationsTo { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
  }
  public class Shallow : I
  {
    public Guid ID { get; set; }
    public Idea.Shallow Idea { get; set; }
    public ThingDefinition.Shallow Definition { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
  }
}