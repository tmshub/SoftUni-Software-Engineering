using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lairSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            char[,] matrix = new char[lairSize[0], lairSize[1]];
            int[] playerPlace = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(input[col] == 'P')
                    {
                        playerPlace[0] = row;
                        playerPlace[1] = col;
                    }
                    matrix[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();
            int[] previousPlayerPosition = new int[2];
            bool isAlive = false;
            bool isDead = false;
            
            for (int i = 0; i < command.Length; i++)
            {
                previousPlayerPosition = playerPlace;

                if (command[i] == 'L')
                {
                    if (playerPlace[1] - 1 < 0)
                    {
                        isAlive = true;
                        matrix[playerPlace[0], playerPlace[1]] = '.';
                    }
                    else
                    {
                        if (matrix[playerPlace[0], playerPlace[1] - 1] == 'B')
                        {
                            isDead = true;
                            matrix[playerPlace[0], playerPlace[1]] = '.';
                            playerPlace[1] = playerPlace[1] - 1;
                        }
                        else
                        {
                            matrix[playerPlace[0], playerPlace[1] - 1] = 'P';
                            matrix[playerPlace[0], playerPlace[1]] = '.';
                            playerPlace[1] = playerPlace[1] - 1;
                        }
                    }
                }
                else if (command[i] == 'R')
                {
                    if (playerPlace[1] + 1 == lairSize[1])
                    {
                        isAlive = true;
                        matrix[playerPlace[0], playerPlace[1]] = '.';
                    }
                    else
                    {
                        if (matrix[playerPlace[0], playerPlace[1] + 1] == 'B')
                        {
                            isDead = true;
                            matrix[playerPlace[0], playerPlace[1]] = '.';
                            playerPlace[1] = playerPlace[1] + 1;
                        }
                        else
                        {
                            matrix[playerPlace[0], playerPlace[1] + 1] = 'P';
                            matrix[playerPlace[0], playerPlace[1]] = '.';
                            playerPlace[1] = playerPlace[1] + 1;
                        }
                    }
                }
                else if (command[i] == 'U')
                {
                    if (playerPlace[0] - 1 < 0)
                    {
                        isAlive = true;
                        matrix[playerPlace[0], playerPlace[1]] = '.';
                    }
                    else
                    {
                        if (matrix[playerPlace[0] - 1, playerPlace[1]] == 'B')
                        {
                            isDead = true;
                            matrix[playerPlace[0], playerPlace[1]] = '.';
                            playerPlace[0] = playerPlace[0] - 1;
                        }
                        else
                        {
                            matrix[playerPlace[0] - 1, playerPlace[1]] = 'P';
                            matrix[playerPlace[0], playerPlace[1]] = '.';
                            playerPlace[0] = playerPlace[0] - 1;
                        }
                    }
                }
                else if (command[i] == 'D')
                {
                    if (playerPlace[0] + 1 == lairSize[0])
                    {
                        isAlive = true;
                        matrix[playerPlace[0], playerPlace[1]] = '.';
                    }
                    else
                    {
                        if (matrix[playerPlace[0] + 1, playerPlace[1]] == 'B')
                        {
                            isDead = true;
                            matrix[playerPlace[0], playerPlace[1]] = '.';
                            playerPlace[0] = playerPlace[0] + 1;
                        }
                        else
                        {
                            matrix[playerPlace[0] + 1, playerPlace[1]] = 'P';
                            matrix[playerPlace[0], playerPlace[1]] = '.';
                            playerPlace[0] = playerPlace[0] + 1;
                        }
                    }
                }
                Queue<int> bunnyPositions = new Queue<int>();
                for (int row = 0; row < lairSize[0]; row++)
                {
                    for (int col = 0; col < lairSize[1]; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (col-1 >= 0)
                            {
                                if (matrix[row, col - 1] == 'P')
                                {
                                    bunnyPositions.Enqueue(row);
                                    bunnyPositions.Enqueue(col-1);
                                    isDead = true;
                                }
                                else
                                {
                                    bunnyPositions.Enqueue(row);
                                    bunnyPositions.Enqueue(col - 1);
                                }
                            }


                            if (col + 1< lairSize[1])
                            {
                                if (matrix[row, col + 1] == 'P')
                                {
                                    bunnyPositions.Enqueue(row);
                                    bunnyPositions.Enqueue(col + 1);
                                    isDead = true;
                                }
                                else
                                {
                                    bunnyPositions.Enqueue(row);
                                    bunnyPositions.Enqueue(col + 1);
                                }
                            }


                            if (row - 1>= 0)
                            {
                                if (matrix[row - 1, col] == 'P')
                                {
                                    bunnyPositions.Enqueue(row-1);
                                    bunnyPositions.Enqueue(col);
                                    isDead = true;
                                }
                                else
                                {
                                    bunnyPositions.Enqueue(row - 1);
                                    bunnyPositions.Enqueue(col);
                                }
                            }

                            if (row + 1< lairSize[0])
                            {
                                if (matrix[row + 1, col] == 'P')
                                {
                                    bunnyPositions.Enqueue(row + 1);
                                    bunnyPositions.Enqueue(col);
                                    isDead = true;
                                }
                                else
                                {
                                    bunnyPositions.Enqueue(row + 1);
                                    bunnyPositions.Enqueue(col);
                                }
                            }
                        }

                    }
                }
                while (bunnyPositions.Any())
                {
                    matrix[bunnyPositions.Dequeue(), bunnyPositions.Dequeue()] = 'B';
                }
                if(isDead || isAlive)
                {
                    break;
                }
            }

            if (isAlive)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row,col]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine($"won: {previousPlayerPosition[0]} {previousPlayerPosition[1]}");
            }
            else
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine($"dead: {previousPlayerPosition[0]} {previousPlayerPosition[1]}");
            }
        }
    }
}
