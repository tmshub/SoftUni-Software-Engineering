using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> queue = new Stack<char>();
            string input = Console.ReadLine();
            bool isValid = true;

            foreach (var item in input)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    queue.Push(item);
                }
                else
                {
                    if (queue.Count == 0)
                    {
                        isValid = false;
                        break;
                    }
                    else if (item == ')' && queue.Pop() == '(')
                    {
                        isValid = true;
                    }
                    else if (item == '}' && queue.Pop() == '{')
                    {
                        isValid = true;
                    }
                    else if (item == ']' && queue.Pop() == '[')
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
