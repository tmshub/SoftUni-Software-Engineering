using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gardenSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = gardenSize[0];
            int colums = gardenSize[1];

            int[,] garden = new int[rows, colums];

            for (int row = 0; row < rows; row++)
            {
                for (int colum = 0; colum < colums; colum++)
                {
                    garden[row, colum] = 0;
                }
            }
            
            string command = Console.ReadLine();
            List<int> coordinatesOfFlowers = new List<int>();

            while (command!= "Bloom Bloom Plow")
            {
                string[] commands = command.Split();

                int row = int.Parse(commands[0]);
                int colum = int.Parse(commands[1]);
                
                if(row < rows && colum < colums)
                {
                    garden[row, colum] = 1;
                    coordinatesOfFlowers.Add(row);
                    coordinatesOfFlowers.Add(colum);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                command = Console.ReadLine();
            }

            while (coordinatesOfFlowers.Count > 0)
            {
                int row = coordinatesOfFlowers[0];
                int colum = coordinatesOfFlowers[1];
                coordinatesOfFlowers.RemoveAt(0);
                coordinatesOfFlowers.RemoveAt(0);


                for (int i = 0; i < rows; i++)
                {
                    if(i == colum)
                    {
                        continue;
                    }
                    garden[row, i] += 1;
                }
                for (int i = 0; i < colums; i++)
                {
                    if(i == row)
                    {
                        continue;
                    }
                    garden[i, colum] += 1;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    Console.Write(garden[i,j]+" ");
                }
                Console.WriteLine();
            }

        }
    }
}
