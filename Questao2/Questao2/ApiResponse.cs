using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Questao2
{
    public class ApiResponse
    {      
        public int TotalPages { get; set; }

        [JsonPropertyName("data")]
        public List<FootballMatch> Data { get; set; }
    }
}
