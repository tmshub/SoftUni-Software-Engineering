using System;
using System.Collections.Generic;
using System.Text;

namespace _07.LinkedList
{
    class LinkedList
    {
        public int Count { get; set; }
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void AddLast(Node node)
        {
            if (Head == null)
            {
                Count++;
                Head = node;
                Tail = node;
                return;
            }
            Count++;
            Tail.Next = node;
            node.Privious = Tail;
            Tail = node;
        }

        public Node RemoveFirst()
        {
            Count--;
            var node = Head;
            Head = Head.Next;
            return node;
        }


        public Node RemoveLast()
        {
            Count--;
            var node = Tail;
            Tail = Tail.Privious;
            Tail.Next = null;
            return node;
        }


        public void AddFirst(Node node)
        {
            if (Head == null)
            {
                Count++;
                Head = node;
                Tail = node;
                return;
            }
            Count++;
            Head.Privious = node;
            node.Next = Head;
            Head = node;
        }

        public int[] ToArray()
        {
            int[] arrayOfNodes = new int[Count];
            int index = 0;
            var node = Head;
            while (node != null)
            {
                arrayOfNodes[index] = node.Value;
                index++;
                node = node.Next;
            }

            return arrayOfNodes;
        }

        public void ForEach(Action<Node> action)
        {
            var node = Head;
            while (node != null)
            {
                action(node);
                node = node.Next;
            }
        }
    }
}
