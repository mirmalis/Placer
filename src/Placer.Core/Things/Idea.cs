using System.Collections.Generic;

namespace Placer.Core
{
  public class Idea : IDed
  {
    public string Name { get; set; }
    public ICollection<Thing> Things { get; set; }
    
  }
}