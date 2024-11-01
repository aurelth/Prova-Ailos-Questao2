using Questao2;

var service = new FootballDataService();

int psgGoals = await service.GetGoalsByTeamAndYearAsync("Paris Saint-Germain", 2013);
Console.WriteLine($"Team Paris Saint-Germain scored {psgGoals} goals in 2013");

int chelseaGoals = await service.GetGoalsByTeamAndYearAsync("Chelsea", 2014);
Console.WriteLine($"Team Chelsea scored {chelseaGoals} goals in 2014");
