using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    public class Box<T> where T: IComparable
    {
        public Box(List<T> myProp)
        {
            MyProp = myProp;
        }

        public List<T> MyProp { get; set; }

        public int CompareElements(T element)
        {
            int count = 0;
            foreach (var item in MyProp)
            {
                if(item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
