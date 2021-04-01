using System;
using System.Collections.Generic;

namespace Placer.Api1.Types.RelationDefinition
{
  public interface I : IIDed<Guid>
  {
    public string Forward { get; set; }
    public string Backward { get; set; }
  }
  public class Deep : I
  {
    public Guid ID { get; set; }
    public string Forward { get; set; }
    public string Backward { get; set; }
  }
  public class Shallow : I
  {
    public Guid ID { get; set; }
    public string Forward { get; set; }
    public string Backward { get; set; }
  }
}

