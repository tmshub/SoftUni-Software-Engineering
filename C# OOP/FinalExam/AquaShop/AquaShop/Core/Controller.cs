using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if(aquariumType == "FreshwaterAquarium")
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if(aquariumType == "SaltwaterAquarium")
            {
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {

            if (decorationType == "Ornament")
            {
                this.decorations.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                this.decorations.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            Fish fish = null;

            if(fishType == "FreshwaterFish")
            {
                // aquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if(fishType == "SaltwaterFish")
            {
                //aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            if (aquarium.GetType().Name == "FreshwaterAquarium" && fishType == "FreshwaterFish")
            {
                aquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else if(aquarium.GetType().Name == "SaltwaterAquarium" && fishType == "SaltwaterFish")
            {
                aquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }

            return "Water not suitable.";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            decimal value = aquarium.Decorations.Sum(x => x.Price) + aquarium.Fish.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {value:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            bool isExsist = false;

            if (this.decorations.FindByType(decorationType) != null)
            {
                IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
                aquarium.AddDecoration(this.decorations.FindByType(decorationType));
                this.decorations.Remove(this.decorations.FindByType(decorationType));
            }
            else
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            
            foreach (var item in this.aquariums)
            {
                sb.AppendLine(item.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
