using System.Runtime.Serialization;

namespace RestWCFServiceLibrary.Use_Cases.HighScores.Models
{
    [DataContract]
    public class HighScore
    {
        [DataMember(Name = "name", IsRequired = true)]
        public string Name { get; set; }

        [DataMember(Name = "score", IsRequired = true)]
        public int Score { get; set; }

        public HighScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
    }
}
