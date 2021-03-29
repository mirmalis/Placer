using System;

namespace Placer.Core
{
  public interface IIDed<TKey>
  {
    public TKey ID { get; set; }
  }
  public class IDed : IIDed<Guid>
  {
    public Guid ID { get; set; } = Guid.NewGuid();
  }
}