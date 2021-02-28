using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        public Team(string name)
        {
            this.name = name;
           firstTeam = new List<Person>();
           reserveTeam = new List<Person>();
        }
            private string name;
            private List<Person> firstTeam;
            private List<Person> reserveTeam;

        public ReadOnlyCollection<Person> FirstTeam 
        { 
            get
            {
                return this.firstTeam.AsReadOnly();
            } 
        }

        public ReadOnlyCollection<Person> ReserveTeam
        {
            get
            {
                return this.firstTeam.AsReadOnly();
            }
            
        }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                firstTeam.Add(player);
            }
            else
            {
                reserveTeam.Add(player);
            }
        }
    }
}
