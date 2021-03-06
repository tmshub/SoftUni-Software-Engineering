﻿using System;
using System.Reflection;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public bool IsAlive { get; set; } = true;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }
        public double BaseArmor { get; private set; }
        public double AbilityPoints { get; private set; }

        public double Health
        {
            get => this.health;
            set
            {
                if (value <= BaseHealth && value > 0)
                {
                    this.health = value;
                }

            }
        }

        public double Armor
        {
            get => this.armor;
            private set
            {
                if (value > 0)
                {
                    this.armor = value;
                }

            }
        }

        public Bag Bag { get; private set; }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (this.armor >= hitPoints)
            {
                this.armor -= hitPoints;
            }
            else
            {
                hitPoints -= this.armor;
                this.armor = 0;

                if (this.health > hitPoints)
                {

                    this.health -= hitPoints;
                }
                else
                {
                    this.health = 0;

                    this.IsAlive = false;
                }
            }
        }
        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);

        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}