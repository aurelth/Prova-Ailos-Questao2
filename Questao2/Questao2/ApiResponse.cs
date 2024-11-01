using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    public class ApiResponse
    {
        public int TotalPages { get; set; }
        public List<FootballMatch> Data { get; set; }
    }
}
