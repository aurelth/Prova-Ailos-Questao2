using System.Text.Json;

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
           
            totalGoals += await GetGoalsAsync(team, year, isTeam1: true);
            
            totalGoals += await GetGoalsAsync(team, year, isTeam1: false);

            return totalGoals;
        }

        private async Task<int> GetGoalsAsync(string team, int year, bool isTeam1)
        {
            int totalGoals = 0;
            int page = 1;
            bool hasMorePages = true;

            string teamParam = isTeam1 ? "team1" : "team2";

            while (hasMorePages)
            {
                var url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&{teamParam}={team}&page={page}";
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse>(content);

                if (result == null || result.Data == null)
                {
                    Console.WriteLine("Falha ao desserializar os dados da API.");
                    return 0;
                }

                foreach (var match in result.Data)
                {
                    if (isTeam1 && match.Team1 == team)
                    {
                        totalGoals += int.TryParse(match.Team1Goals, out int goals) ? goals : 0;
                    }
                    else if (!isTeam1 && match.Team2 == team)
                    {
                        totalGoals += int.TryParse(match.Team2Goals, out int goals) ? goals : 0;
                    }
                }

                page++;
                hasMorePages = page <= result.TotalPages;
            }

            return totalGoals;
        }
    }
}
