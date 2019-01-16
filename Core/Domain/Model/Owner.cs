using Newtonsoft.Json;

namespace Core.Domain.Model
{
    public class Owner
    {
        [JsonProperty(PropertyName = "login")]
        public string login { get; set; }

        [JsonProperty(PropertyName = "avatarUrl")]
        public string avatarUrl { get; set; }
    }
}
