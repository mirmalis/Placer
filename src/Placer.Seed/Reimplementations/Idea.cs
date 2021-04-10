using System;
using System.Linq;
using System.Collections.Generic;

namespace Placer.Seed.Reimplementations
{
  class Idea : Core.Idea
  {
    #region Constructors
    public Idea() { }
    public Idea(Scope scope, string name, int x = 0, int y = 0, int z = 0) : base()
    {
      if (scope != null)
      {
        this.Scope = scope;
        this.ScopeLocation = new Core.ScopeLocation(x, y, z);
      }
      this.Name = name;
    }
    public Idea(string name, int x = 0, int y = 0, int z = 0) : this(null, name, x, y, z)
    {
    }
    #endregion
    public Thing DefinitionAssignment => (Thing)Things.Last(item => true);
    public Thing AddDefinition(Core.ThingDefinition definition)
    {
      if (definition == null)
      {
        throw new ArgumentNullException("definition cannot be null");
      }
      this.Things ??= new List<Core.Thing>();
      var result = new Thing(definition, this);
      this.Things.Add(result);
      return result;
    }
  }
}
