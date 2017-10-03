
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RestWCFServiceLibrary.Use_Cases.HighScores.Models
{
    [DataContract]
    public class HighScore
    {
        [DataMember(Name = "id", Order = 1)]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name", IsRequired = true, Order = 2)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [DataMember(Name = "score", IsRequired = true, Order = 3)]
        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }
    }
}
