using System;
using System.Collections.Generic;

namespace Placer.Api1.Types.Field
{
  public interface I<TInstance> : IIDed<Guid>
  {
    public TInstance Instance { get; set; }
    public FieldDefinition.Shallow FieldDefinition { get; set; }
    public byte[] Data { get; set; }
  }

  public class Deep<TInstance> : I<TInstance>
  {
    public Guid ID { get; set; }
    public TInstance Instance { get; set; }
    public FieldDefinition.Shallow FieldDefinition { get; set; }
    public byte[] Data { get; set; }
    public string String { get; set; }
  }
  public class Shallow<TInstance> : I<TInstance>
  {
    public Guid ID { get; set; }
    public TInstance Instance { get; set; }
    public FieldDefinition.Shallow FieldDefinition { get; set; }
    public byte[] Data { get; set; }
  }
}
