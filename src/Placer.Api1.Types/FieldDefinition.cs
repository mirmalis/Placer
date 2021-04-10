using System;
using System.Collections.Generic;

namespace Placer.Api1.Types.FieldDefinition
{
  public interface I : IIDed<Guid>
  {
    public string Name { get; set; }
    public bool? IsTimeSeries { get; set; }
  }
  public class Deep : I
  {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public bool? IsTimeSeries { get; set; }
  }
  public class Shallow : I
  {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public bool? IsTimeSeries { get; set; }
  }
}
