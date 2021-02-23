using System;

namespace _07.LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddFirst(new Node(i));
            }
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(new Node(i));
            }


            Console.WriteLine("Delete Head: " + linkedList.RemoveFirst().Value);
            Console.WriteLine("Delete Head: " + linkedList.RemoveFirst().Value);
            Console.WriteLine("Delete Head: " + linkedList.RemoveFirst().Value);
            Console.WriteLine("Delete Tail: " + linkedList.RemoveLast().Value);
            Console.WriteLine("Delete Tail: " + linkedList.RemoveLast().Value);
            Console.WriteLine("Delete Tail: " + linkedList.RemoveLast().Value);
            Node currentNode = linkedList.Head;

            linkedList.ForEach((currentNode)
                   =>
                   {
                       Console.WriteLine(currentNode.Value);
                   });

            int[] arr = linkedList.ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
