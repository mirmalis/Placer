using System;
using System.Collections.Generic;

namespace Placer.Core
{
  public class Idea : IDed
  {
    public Scope Scope { get; set; } public Guid? ScopeID { get; set; }
    public ScopeLocation ScopeLocation { get; set; }
    public string Name { get; set; }
    public ICollection<Thing> Things { get; set; }
  }
}