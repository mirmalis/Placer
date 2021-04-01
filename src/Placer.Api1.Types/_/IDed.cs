using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Api1.Types
{
  public class IDed : IIDed<Guid>
  {
    #region Constructors
    public IDed() { }
    public IDed(Guid id) : base()
    {
      this.ID = id;
    }
    #endregion
    public Guid ID { get; set; }
  }
}
