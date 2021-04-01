using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Placer.Api1.Types.Scope;

namespace Placer.Api1
{
  public partial class Client
  {
    public async Task<IEnumerable<Shallow>> GetScopes() =>
      await this.HttpClient.GetFromJsonAsync<IEnumerable<Shallow>>($"/api/scopes");
    public async Task<Deep> GetScope(Guid id) =>
      await this.HttpClient.GetFromJsonAsync<Deep>($"/api/scopes/{id}");

    public async Task<HttpResponseMessage> CreateScope(Shallow scope) =>
      await this.HttpClient.PostAsJsonAsync<Shallow>("/api/scopes/", scope);
    public async Task<HttpResponseMessage> DeleteScope(Guid id) =>
      await this.HttpClient.DeleteAsync($"/api/scopes/{id}");
  }
}
