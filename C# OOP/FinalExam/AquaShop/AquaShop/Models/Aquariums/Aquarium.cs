using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }
        
        public int Capacity { get; private set; }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.AsReadOnly();

        public ICollection<IFish> Fish => this.fishes.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if(this.fishes.Count + 1 > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (var item in this.fishes)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            if (this.fishes.Count == 0)
            {
                sb.AppendLine($"{Name} ({this.GetType().Name}):");
                sb.AppendLine($"Fish: none");
                sb.AppendLine($"Decorations: {this.decorations.Count}");
                sb.AppendLine($"Comfort: {Comfort}");

                return sb.ToString().TrimEnd();
            }

            sb.AppendLine($"{Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {string.Join(", ", fishes.Select(x => x.Name))}");
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            bool isExsist = this.fishes.Any(x => x.Name == fish.Name);
            if (isExsist)
            {
                this.fishes.Remove(fish);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
                                                                                          
           sb.AppendLine($"{Name} ({this.GetType().Name}):");
           sb.AppendLine($"Fish: {string.Join(", ", this.fishes)}");
           sb.AppendLine($"Decorations: {this.decorations.Count}");
           sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
