using Newtonsoft.Json;

namespace Domain.Model
{
    public class Owner
    {
        [JsonProperty(PropertyName = "login")]
        public string login { get; set; }

        [JsonProperty(PropertyName = "avatarUrl")]
        public string avatarUrl { get; set; }
    }
}
