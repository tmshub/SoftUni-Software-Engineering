using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T1, T2> 
        where T1 : IComparable
        where T2 : IComparable
    {
        public EqualityScale(T1 firstElement, T2 secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
        }

        public T1 FirstElement { get; set; }
        public T2 SecondElement { get; set; }

        public bool AreEqual()
        {
            if(FirstElement.CompareTo(SecondElement) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
