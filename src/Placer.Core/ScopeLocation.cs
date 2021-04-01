using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core
{
  [Owned]
  public class ScopeLocation
  {
    #region Constructors
    public ScopeLocation() { }
    public ScopeLocation(int x, int y, int z) : base()
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }
    #endregion
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
  }
}
