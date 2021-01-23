using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());
            
            while (stack.Count>1)
            {
                int firstNumber = int.Parse(stack.Pop());
                char sign = char.Parse(stack.Pop());
                int secondNumber = int.Parse(stack.Pop());

                if (sign == '+')
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }

            }

            Console.WriteLine(string.Join("", stack));
        }
    }
}
