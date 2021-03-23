﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;
       
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.IsNullOrEmpty(value, "Name cannot be empty");
                this.name = value;
            }
        }
        public decimal Cost
        {
            get => this.cost;
            private set
            {
                Validator.IsNegativeNumber(value, "Money cannot be negative");
                this.cost = value;
            }
        }
    }
}