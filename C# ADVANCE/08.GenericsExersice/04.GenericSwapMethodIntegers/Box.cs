using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodIntegers
{
    public class Box<T>
    {
        public Box(List<T> list)
        {
            MyBox = list;
        }

        public List<T> MyBox { get; set; }

        public void Swap(int firstIndex, int secondIndex)
        {
            T currrentElement = MyBox[firstIndex];
            MyBox[firstIndex] = MyBox[secondIndex];
            MyBox[secondIndex] = currrentElement;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in MyBox)
            {
                sb.AppendLine($"{item.GetType()}: {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
