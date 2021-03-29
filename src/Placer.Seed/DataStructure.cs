using System;
using System.Collections.Generic;
using Placer.Seed.Reimplementations;

namespace Placer.Seed
{
  internal class DataStructure
  {
    private readonly List<Core.Idea> ideas = new();
    public void AddRange(params Core.Idea[] elements) => ideas.AddRange(elements);
    private readonly List<Core.ThingDefinition> thingDefinitions = new();
    public void AddRange(params Core.ThingDefinition[] elements) => thingDefinitions.AddRange(elements);
    private readonly List<Core.Thing> thingDefinitionAssignments = new();
    public void AddRange(params Core.Thing[] elements) => thingDefinitionAssignments.AddRange(elements);

    public void Inject(Db.PlacerContext context, bool ensureDeleted = false)
    {
      if (ensureDeleted)
        context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      context.AddRange(ideas);
      context.AddRange(thingDefinitions);
      context.AddRange(thingDefinitionAssignments);

      context.SaveChanges();
    }
  }
}
