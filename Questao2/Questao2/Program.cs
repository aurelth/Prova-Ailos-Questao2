using Questao2;
using System;
using System.Threading.Tasks;

var service = new FootballDataService();

// Exemplo de uso para calcular gols
int psgGoals = await service.GetGoalsByTeamAndYearAsync("Paris Saint-Germain", 2013);
Console.WriteLine($"Team Paris Saint-Germain scored {psgGoals} goals in 2013");

int chelseaGoals = await service.GetGoalsByTeamAndYearAsync("Chelsea", 2014);
Console.WriteLine($"Team Chelsea scored {chelseaGoals} goals in 2014");
