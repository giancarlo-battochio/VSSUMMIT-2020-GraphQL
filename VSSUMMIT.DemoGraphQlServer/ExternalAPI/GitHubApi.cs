using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace VSSUMMIT.Demo00.ExternalAPI
{
    public class GitHubApi
    {
        private readonly IHttpClientFactory _clientFactory;

        private bool GetBranchesError { get; set; }
        private const string URI = "https://api.github.com/repos/aspnet/AspNetCore.Docs/branches";

        public GitHubApi(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IEnumerable<GitHubBranch> GetBranches()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URI);

            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();
            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<IEnumerable<GitHubBranch>>(responseStream);
            }
            else
            {
                GetBranchesError = true;
                return Array.Empty<GitHubBranch>();
            }
        }
    }
}
