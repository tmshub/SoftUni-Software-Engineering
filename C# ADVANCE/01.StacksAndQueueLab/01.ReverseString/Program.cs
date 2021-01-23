using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input.Length);

            foreach (var item in input)
            {
                stack.Push(item);
            }

            Console.WriteLine(string.Join("",stack));
        }
    }
}
