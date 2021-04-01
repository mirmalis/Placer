using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placer.Api1.Types.ThingDefinition
{
  public interface I : IIDed<Guid>
  {
    public string Name { get; set; }
    public ScopeLocation Scope { get; set; }
  }
  public class Deep : I
  {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public ScopeLocation Scope { get; set; }
    public IEnumerable<Thing.Shallow> Instances { get; set; }
  }
  public class Shallow : I
  {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public ScopeLocation Scope { get; set; }
  }
}
