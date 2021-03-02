using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        List<T> Item;

        public Box()
        {
            Item = new List<T>();
        }
        public int Count { get { return Item.Count; } }

        public void Add(T element)
        {
            Item.Insert(0, element);
        }

        public T Remove()
        {
            T element = Item[0];
            Item.RemoveAt(0);
            return element;
        }
    }
}
