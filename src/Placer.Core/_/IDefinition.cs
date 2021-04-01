using System;
using System.Collections.Generic;

namespace Placer.Core
{
  public interface IDefinition : IIDed<Guid>
  {
  }
  public interface IDefinition<TInstance> : IDefinition
    where TInstance: IInstance
  {
    public ICollection<TInstance> Instances { get; set; }
  }
}
