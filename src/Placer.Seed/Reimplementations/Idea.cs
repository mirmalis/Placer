using System;
using System.Linq;
using System.Collections.Generic;

namespace Placer.Seed.Reimplementations
{
  class Idea : Core.Idea
  {
    #region Constructors
    public Idea() { }
    public Idea(string name) : base()
    {
      this.Name = name;
    }
    #endregion
    public Thing DefinitionAssignment => (Thing)Things.Last(item => true);
    public Thing AddDefinition(ThingDefinition definition)
    {
      if (definition == null) { 
        throw new ArgumentNullException("definition cannot be null");
      }
      this.Things ??= new List<Core.Thing>();
      var result = new Thing(definition, this);
      this.Things.Add(result);
      return result;
    }
  }
}
