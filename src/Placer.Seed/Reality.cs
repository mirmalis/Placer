using Placer.Seed.Reimplementations;

namespace Placer.Seed
{
  static class Reality
  {
    internal static readonly Scope Scope = new Scope("Reality", null);
    internal static readonly Scope Internet = new Scope("Internet", Scope);
    internal static readonly Idea Minutes = new Idea(null, "Minutes");
    internal static readonly Idea Hours = new Idea(null, "Hours");
    internal static readonly Idea Years = new Idea(null, "Years");

    internal static RelationDefinition dalyvavo = new RelationDefinition(Scope, "dalyvavo", "buvo dalyvis");
  }
}