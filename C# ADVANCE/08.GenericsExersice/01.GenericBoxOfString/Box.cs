using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    class Box<T>
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
