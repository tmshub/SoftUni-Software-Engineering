using System;
using System.Collections.Generic;
using System.Text;

namespace _07.LinkedList
{
    class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public Node Next { get; set; }   
        public Node Privious { get; set; }   

       
    }
}
