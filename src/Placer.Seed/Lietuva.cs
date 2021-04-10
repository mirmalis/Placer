using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Placer.Seed.Reimplementations;

namespace Placer.Seed
{
  internal static class Lietuva
  {
    
    static Core.ThingDefinition Grupe = new ThingDefinition(Reality.Scope, "Grupė" );
    internal static Thing Ugniavijas = new Thing(Grupe, new Idea("Ugniavijas"));
  }
}
