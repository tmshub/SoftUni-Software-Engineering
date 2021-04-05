using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;
        private int capacity;
            public Bag(int capacity)
        {
            items = new List<Item>();
            Capacity = capacity;
        }
        public int Capacity { get { return capacity; } set { this.capacity = value; } }

        public int Load => items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if(Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item currentItem = null;

            if(items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            foreach (var item in items)
            {
                if(item.GetType().Name == name)
                {
                    currentItem = item;
                }
            }
            
            if(currentItem == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(currentItem);

            return currentItem;
        }
    }
}
