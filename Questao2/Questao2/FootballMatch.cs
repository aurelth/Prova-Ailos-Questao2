using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Questao2
{
    public class FootballMatch
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }

        [JsonPropertyName("team1goals")]
        public string Team1Goals { get; set; }

        [JsonPropertyName("team2goals")]
        public string Team2Goals { get; set; }
    }
}
