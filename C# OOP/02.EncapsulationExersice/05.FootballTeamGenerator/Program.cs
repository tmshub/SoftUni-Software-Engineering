using System;
using System.Collections.Generic;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> dictionary = new Dictionary<string, Team>();
            string[] command = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                string currentTeam = command[1];
                try
                {
                    if (command[0] == "Add")
                    {
                        if (dictionary.ContainsKey(currentTeam))
                        {
                            string currentPlayer = command[2];
                            double endurance = int.Parse(command[3]);
                            double sprint = int.Parse(command[4]);
                            double dribble = int.Parse(command[5]);
                            double passing = int.Parse(command[6]);
                            double shooting = int.Parse(command[7]);
                            Player player = new Player(currentPlayer, endurance, sprint, dribble, passing, shooting);
                            dictionary[currentTeam].AddPlayer(player, currentTeam);
                        }
                        else
                        {
                            throw new ArgumentException($"Team {currentTeam} does not exist.");
                        }
                    }
                    else if (command[0] == "Remove")
                    {
                        if (dictionary.ContainsKey(currentTeam))
                        {
                        string currentPlayer = command[2];
                        dictionary[currentTeam].RemovePlayer(currentTeam, currentPlayer);
                        }
                        else
                        {
                            throw new ArgumentException($"Team {currentTeam} does not exist.");
                        }
                    }
                    else if(command[0] == "Rating")
                    {
                        if (dictionary.ContainsKey(currentTeam))
                        {
                            Console.WriteLine($"{currentTeam} - {dictionary[currentTeam].AverageScore}");
                        }
                        else
                        {
                            throw new ArgumentException($"Team {currentTeam} does not exist.");
                        }
                    }
                    else if(command[0] == "Team")
                    {
                        Team team1 = new Team(currentTeam);
                        dictionary.Add(currentTeam, team1);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                command = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            
            }
        }
    }
}
