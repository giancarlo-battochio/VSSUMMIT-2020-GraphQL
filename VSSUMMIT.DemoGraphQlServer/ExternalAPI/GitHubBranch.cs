using System.Text.Json.Serialization;

namespace VSSUMMIT.Demo00.ExternalAPI
{
    public class GitHubBranch
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
