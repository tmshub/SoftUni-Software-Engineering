using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalCommands = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> previousOperation = new Stack<string>();

            for (int i = 0; i < totalCommands; i++)
            {
                string[] commandSplit = Console.ReadLine().Split();

                if (commandSplit[0] == "1")
                {
                    previousOperation.Push(text.ToString());
                    previousOperation.Push(commandSplit[0]);
                    text.Append(commandSplit[1]);
                }
                else if (commandSplit[0] == "2")
                {
                    previousOperation.Push(text.ToString());
                    previousOperation.Push(commandSplit[0]);
                    int elementsForDel = int.Parse(commandSplit[1]);
                    text = text.Remove(text.Length - elementsForDel, elementsForDel);
                }
                else if (commandSplit[0] == "3")
                {
                    char index = text[int.Parse(commandSplit[1]) - 1];
                    Console.WriteLine(index);
                }
                else
                {
                    if (previousOperation.Peek() == "2")
                    {
                        text.Clear();
                        previousOperation.Pop();
                        text.Append(previousOperation.Pop());
                    }
                    else if (previousOperation.Peek() == "1")
                    {
                        text = text.Clear();
                        previousOperation.Pop();
                        text.Append(previousOperation.Pop());
                    }
                }
            }
        }
    }
}
