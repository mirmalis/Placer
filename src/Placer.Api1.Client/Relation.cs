using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Placer.Api1.Types.Relation;

namespace Placer.Api1
{
  public partial class Client
  {
    public async Task<Deep> GetRelation(Guid id) =>
      await HttpClient.GetFromJsonAsync<Deep>($"/api/relations/{id}");
    public async Task<IEnumerable<Shallow>> GetRelations(Guid? fromID, Guid? definitionID, Guid? toID)
    {
      var str = "/api/relations/" + (fromID == null, definitionID == null, toID == null) switch 
      {
        (true, true, true) => throw new Exception("Provide some data"),
        (false, true, true) => $"x/{fromID}",
        (true, false, true) => $"y/{definitionID}",
        (true, true, false) => $"z/{toID}",
        (false, false, true) => $"xy/{fromID}/{definitionID}",
        (false, true, false) => $"xz/{fromID}/{toID}",
        (true, false, false) => $"yz/{definitionID}/{toID}",
        (false, false, false) => $"xyz/{fromID}/{definitionID}/{toID}"
      };
      return await HttpClient.GetFromJsonAsync<IEnumerable<Shallow>>(str);
  }
}
}

