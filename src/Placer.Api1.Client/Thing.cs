using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Placer.Api1.Types.Thing;

namespace Placer.Api1
{
  public partial class Client
  {
    public async Task<Deep> GetThing(Guid ID) =>
      await HttpClient.GetFromJsonAsync<Deep>($"/api/things/{ID}");
  }
}
