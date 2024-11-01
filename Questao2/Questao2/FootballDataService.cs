using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Questao2
{
    public class FootballDataService
    {
        private readonly HttpClient _httpClient;

        public FootballDataService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<int> GetGoalsByTeamAndYearAsync(string team, int year)
        {
            int totalGoals = 0;
            int page = 1;
            bool hasMorePages = true;

            while (hasMorePages)
            {
                var url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={page}";
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse>(content);

                foreach (var match in result.Data)
                {
                    if (match.Team1 == team)
                    {
                        totalGoals += match.Team1Goals;
                    }
                    else if (match.Team2 == team)
                    {
                        totalGoals += match.Team2Goals;
                    }
                }

                page++;
                hasMorePages = page <= result.TotalPages;
            }

            return totalGoals;
        }
    }
}
