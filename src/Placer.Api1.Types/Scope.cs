using System;
using System.Collections.Generic;

namespace Placer.Api1.Types.Scope
{
  public interface I : IIDed<Guid>
  {
    public string Name { get; set; }
    public IDed Parent { get; set; }
  }
  public class Deep : I
  {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public IDed Parent { get; set; }
    public IEnumerable<Types.ThingDefinition.Shallow> ThingDefinitions { get; set; }
    public IEnumerable<Types.Scope.Shallow> Children { get; set; }
  }
  public class Shallow : I
  {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public IDed Parent { get; set; }
  }
}
