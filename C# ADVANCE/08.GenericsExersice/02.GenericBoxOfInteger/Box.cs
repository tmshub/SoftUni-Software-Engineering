using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T text)
        {
            Text = text;
        }

        public T Text { get; set; }

        public override string ToString()
        {
            return $"{Text.GetType()}: {Text}";
        }
    }
}
