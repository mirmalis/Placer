using System;

namespace Placer.Core
{
  public interface IInstance : IIDed<Guid>
  {
  }
  public interface IInstance<TDefinition> : IInstance
    where TDefinition: IDefinition
  {
    public TDefinition Definition { get; set; } public Guid DefinitionID { get; set; }
  }
}
