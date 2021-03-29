using System;
using System.Collections.Generic;
using System.Text;

namespace Placer.Seed.Reimplementations
{
  class Scope : Core.Scope
  {
    #region Constructors
    public Scope() { }
    public Scope(string name, Scope parent) : base()
    {
      this.Name = name;
      this.Parent = parent;
    }
    #endregion
  }
}
