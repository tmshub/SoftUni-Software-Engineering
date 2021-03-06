using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
       private string name;

        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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
        public double Endurance
        {
            get => endurance;
            private set
            {
                Validator.IsInRange(value, "Endurance should be between 0 and 100.");
                this.endurance = value;
            }
        }
        public double Sprint
        {
            get => sprint;
            private set
            {
                Validator.IsInRange(value, "Sprint should be between 0 and 100.");
                this.sprint = value;
            }
        }
        public double Dribble
        {
            get => dribble;
            private set
            {
                Validator.IsInRange(value, "Dribble should be between 0 and 100.");
                this.dribble = value;
            }
        }
        public double Passing
        {
            get => passing;
            private set
            {
                Validator.IsInRange(value, "Passing should be between 0 and 100.");
                this.passing = value;
            }
        }
        public double Shooting
        {
            get => shooting;
            private set
            {
                Validator.IsInRange(value, "Shooting should be between 0 and 100.");
                this.shooting = value;
            }
        }

        public double Stats => Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / 5.0);
        }
    }

