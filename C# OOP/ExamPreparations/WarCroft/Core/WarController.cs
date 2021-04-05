using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
using System.Text;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> party;
        private List<Item> pool;
        public WarController()
        {
            party = new List<Character>();
            pool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            if (characterType == "Warrior")
            {
                party.Add(new Warrior(name));
            }
            else if (characterType == "Priest")
            {
                party.Add(new Priest(name));
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemType = args[0];

            if (itemType == "HealthPotion")
            {
                pool.Add(new HealthPotion());
            }
            else if (itemType == "FirePotion")
            {
                pool.Add(new FirePotion());
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{itemType}\"!");
            }

            return $"{itemType} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            bool isExsist = party.Any(x => x.Name == characterName);

            if (!isExsist)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (pool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Character character = party.FirstOrDefault(x => x.Name == characterName);
            Item item = pool[pool.Count - 1];
            character.Bag.AddItem(item);
            pool.RemoveAt(pool.Count - 1);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            bool isExsist = party.Any(x => x.Name == characterName);
            if (!isExsist)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Character character = party.FirstOrDefault(x => x.Name == characterName);
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                if (character.IsAlive)
                {
                    sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: Alive");
                }
                else
                {
                    sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: Dead");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            bool isAttackerExsist = party.Any(x => x.Name == attackerName);
            bool isreceiverExsist = party.Any(x => x.Name == receiverName);

            if (!isAttackerExsist)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (!isreceiverExsist)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Character attacker = party.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = party.FirstOrDefault(x => x.Name == receiverName);

            if(attacker.GetType().Name == "Priest")
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            Warrior warrior = (Warrior)attacker;
            //if(receiver.Health == 0)
            //{
            //    throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            //}
            
            warrior.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {warrior.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if(receiver.Health == 0)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            bool isHealerExsist = party.Any(x => x.Name == healerName);
            bool isReceiverExsist = party.Any(x => x.Name == healingReceiverName);

            if (!isHealerExsist)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (!isReceiverExsist)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            Character healer = party.FirstOrDefault(x => x.Name == healerName);

            if(healer.GetType().Name == "Warrior" || healer.IsAlive == false)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            Character receiver = party.FirstOrDefault(x => x.Name == healingReceiverName);
            IHealer priest = (Priest)healer;
            //if (receiver.Health == 0)
            //{
            //    throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            //}
            priest.Heal(receiver);

            return $"{ healer.Name} heals { receiver.Name} for { healer.AbilityPoints}! { receiver.Name} has { receiver.Health} health now!";
        }
    }
}
