using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Placer.Api1
{
  public partial class Client
  {
    #region Constructors
    public Client(HttpClient httpClient) : base()
    {
      this.HttpClient = httpClient;
    }
    HttpClient HttpClient { get; set; }
    #endregion

    

    

    //public async Task<IEnumerable<Types.ThingDefinitions.Shallow>> GetThingDefinitions() =>
    //  await HttpClient.GetFromJsonAsync<IEnumerable<Types.ThingDefinitions.Shallow>>($"/api/thingDefinitions");
    //public async Task<Types.ThingDefinitions.Deep> GetThingDefinition(Guid id) =>
    //  await HttpClient.GetFromJsonAsync<Types.ThingDefinitions.Deep>($"/api/thingDefinitions/{id}");
    //public async Task<Types.ThingInstances.Deep> GetThingInstance(Guid id) =>
    //  await HttpClient.GetFromJsonAsync<Types.ThingInstances.Deep>($"/api/thingInstances/{id}");
  }
}
