using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
   public class Tuple<item1, item2>
    {
        public Tuple(item1 firstItem, item2 secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }

        public item1 FirstItem { get; set; }
        public item2 SecondItem { get; set; }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
