namespace Placer.Api1.Types
{
  public interface IIDed<TKey>
  {
    public TKey ID { get; set; }
  }
}
