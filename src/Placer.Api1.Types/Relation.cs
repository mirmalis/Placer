using System;
using System.Collections.Generic;

namespace Placer.Api1.Types.Relation
{
  public interface I : IIDed<Guid>
  {
    public RelationDefinition.Shallow Definition { get; set; }
    public Thing.Shallow From { get; set; }
    public Thing.Shallow To { get; set; }
  }
  public class Deep : I
  {
    public Guid ID { get; set; }
    public RelationDefinition.Shallow Definition { get; set; }
    public Thing.Shallow From { get; set; }
    public Thing.Shallow To { get; set; }
    public IEnumerable<Field.Deep<Deep>> Fields { get; set; }
  }
  public class Shallow : I
  {
    public Guid ID { get; set; }
    public RelationDefinition.Shallow Definition { get; set; }
    public Thing.Shallow From { get; set; }
    public Thing.Shallow To { get; set; }
  }
}
