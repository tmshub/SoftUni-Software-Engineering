using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(input);

            while (true)
            {
                string commands = Console.ReadLine();
                string[] command = commands.Split();
                if (songs.Count > 0)
                {
                    if (command[0] == "Play")
                    {
                        songs.Dequeue();
                    }
                    else if (command[0] == "Add")
                    {
                        string song = commands.Substring(4, commands.Length - 4);

                        if (songs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(song);
                        }
                    }
                    else if (command[0] == "Show")
                    {
                        Console.Write(string.Join(", ", songs));
                        Console.WriteLine();
                    }
                }
                
                if(songs.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }
                
            }

            
        }
    }
}
