using Newtonsoft.Json;

namespace Core.Domain.Model
{
    public class RepoOrganization
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string language { get; set; }

        [JsonProperty(PropertyName = "html_url")]
        public string htmlUrl { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public Owner owner { get; set; }
    }
}
