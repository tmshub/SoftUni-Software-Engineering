using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> list = new List<string>();
            Stack<string> stack = new Stack<string>();
            Stack<int> braketsPosition = new Stack<int>();
           
            for (int i = 0; i < input.Length; i++) //1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
            {
                if(input[i] == '(')
                {
                    braketsPosition.Push(i);
                }
                else if(input[i] == ')')
                {
                    int possition = braketsPosition.Pop();
                    string subString = input.Substring(possition, i-possition + 1);
                    list.Add(subString);
                }
            }
            
            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
