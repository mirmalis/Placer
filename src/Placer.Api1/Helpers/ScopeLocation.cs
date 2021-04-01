using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placer.Api1.Helpers
{
  public class ScopeLocation : Types.ScopeLocation
  {
    #region Constructors
    public ScopeLocation() { }
    public ScopeLocation(Scope.Shallow scope, Core.ScopeLocation scopeLocation) : base()
    {
      this.Scope = scope;
      this.X = scopeLocation.X;
      this.Y = scopeLocation.Y;
      this.Z = scopeLocation.Z;
    }
    #endregion
  }
}
