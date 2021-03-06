using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private List<Player> numOfPlayers;
        private string name;

        public Team(string name)
        {
            Name = name;
            numOfPlayers = new List<Player>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double AverageScore
        {
            get
            {
                if (numOfPlayers.Count == 0)
                {
                    return 0;
                }
                return Math.Round(numOfPlayers.Select(x => x.Stats).Average());
            }
        }
        public void RemovePlayer(string team, string name)
        {
            bool isExist = this.numOfPlayers.Exists(x => x.Name == name);

            if (isExist)
            {
                foreach (var player in numOfPlayers)
                {
                    if (player.Name == name)
                    {
                        this.numOfPlayers.Remove(player);
                        break;
                    }
                }
            }
            else
            {

            throw new ArgumentException($"Player {name} is not in {team} team.");
            }
            
        }
        public void AddPlayer(Player player, string team)
        {
            numOfPlayers.Add(player);
        }


    }
}
