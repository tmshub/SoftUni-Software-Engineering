using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n,n];
            int pollinateFlowers = 0;
            int beePositionRow = 0;
            int beePositionColum = 0;
            Action<char[,], int> action = new Action<char[,], int>((x, n) =>
           {
               Console.WriteLine("The bee got lost!");
               if (pollinateFlowers >= 5)
               {
                   Console.WriteLine($"Great job, the bee managed to pollinate {pollinateFlowers} flowers!");
               }
               else
               {
                   Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinateFlowers} flowers more");
               }
               for (int i = 0; i < matrix.GetLength(0); i++)
               {
                   for (int j = 0; j < matrix.GetLength(1); j++)
                   {
                       Console.Write(matrix[i, j]);
                   }
                   Console.WriteLine();
               }
               return;
           });

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                for (int j = 0; j < input[0].Length; j++)
                {
                    char symbol = char.Parse(input[0][j].ToString());
                    if(symbol == 'B')
                    {
                        beePositionRow = i;
                        beePositionColum = j;
                    }
                    matrix[i, j] = symbol;
                }
            }

            string command = Console.ReadLine();

            while (command!="End")
            {
                if (command == "right")
                {
                    if (beePositionColum + 1 == n)     
                    {
                        matrix[beePositionRow, beePositionColum] = '.';
                        action(matrix, pollinateFlowers);
                        return;
                    }
                    else
                    {
                        matrix[beePositionRow, beePositionColum] = '.';
                        beePositionColum++;
                        if (matrix[beePositionRow, beePositionColum] == 'f')
                        {
                            matrix[beePositionRow, beePositionColum] = 'B';
                            pollinateFlowers++;
                        }
                        else if(matrix[beePositionRow, beePositionColum] == '.')
                        {
                            matrix[beePositionRow, beePositionColum] = 'B';
                        }
                        else if (matrix[beePositionRow, beePositionColum] == 'O')
                        {
                            matrix[beePositionRow, beePositionColum] = '.';

                            if (beePositionColum + 1 == n)
                            {
                                matrix[beePositionRow, beePositionColum] = '.';
                                action(matrix, pollinateFlowers);
                                return;
                            }
                            else
                            {
                                beePositionColum++;
                                if (matrix[beePositionRow, beePositionColum] == 'f')
                                {
                                    matrix[beePositionRow, beePositionColum] = 'B';
                                    pollinateFlowers++;
                                }
                                else if (matrix[beePositionRow, beePositionColum] == '.')
                                {
                                    matrix[beePositionRow, beePositionColum] = 'B';
                                }
                            }
                        }
                    }
                }
                else if (command == "left")
                {
                    if (beePositionColum - 1 < 0)
                    {
                        matrix[beePositionRow, beePositionColum] = '.';
                        action(matrix, pollinateFlowers);
                        return;
                    }
                    else
                    {
                        matrix[beePositionRow, beePositionColum] = '.';
                        beePositionColum--;
                        if (matrix[beePositionRow, beePositionColum] == 'f')
                        {
                            matrix[beePositionRow, beePositionColum] = 'B';
                            pollinateFlowers++;
                        }
                        else if (matrix[beePositionRow, beePositionColum] == '.')
                        {
                            matrix[beePositionRow, beePositionColum] = 'B';
                        }
                        else if (matrix[beePositionRow, beePositionColum] == 'O')
                        {
                            matrix[beePositionRow, beePositionColum] = '.';

                            if (beePositionColum - 1 < 0)
                            {
                                matrix[beePositionRow, beePositionColum] = '.';
                                action(matrix, pollinateFlowers);
                                return;
                            }
                            else
                            {
                                beePositionColum--;
                                if (matrix[beePositionRow, beePositionColum] == 'f')
                                {
                                    matrix[beePositionRow, beePositionColum] = 'B';
                                    pollinateFlowers++;
                                }
                                else if(matrix[beePositionRow, beePositionColum] == '.')
                                {
                                    matrix[beePositionRow, beePositionColum] = 'B';
                                }
                            }
                        }
                    }
                }
                else if (command == "up")
                {
                    if (beePositionRow - 1 < 0)
                    {
                        matrix[beePositionRow, beePositionColum] = '.';
                        action(matrix, pollinateFlowers);
                        return;
                    }
                    else
                    {
                        matrix[beePositionRow, beePositionColum] = '.';
                        beePositionRow--;
                        if (matrix[beePositionRow, beePositionColum] == 'f')
                        {
                            matrix[beePositionRow, beePositionColum] = 'B';
                            pollinateFlowers++;
                        }
                        else if (matrix[beePositionRow, beePositionColum] == '.')
                        {
                            matrix[beePositionRow, beePositionColum] = 'B';
                        }
                        else if (matrix[beePositionRow, beePositionColum] == 'O')
                        {
                            matrix[beePositionRow, beePositionColum] = '.';

                            if (beePositionRow - 1 < 0)
                            {
                                matrix[beePositionRow, beePositionColum] = '.';
                                action(matrix, pollinateFlowers);
                                return;
                            }
                            else
                            {
                                beePositionRow--;
                                if (matrix[beePositionRow, beePositionColum] == 'f')
                                {
                                    matrix[beePositionRow, beePositionColum] = 'B';
                                    pollinateFlowers++;
                                }
                                else if (matrix[beePositionRow, beePositionColum] == '.')
                                {
                                    matrix[beePositionRow, beePositionColum] = 'B';
                                }
                            }
                        }
                    }
                }
                else if (command == "down")
                {
                    if (beePositionRow + 1 == n)
                    {
                        matrix[beePositionRow, beePositionColum] = '.';
                        action(matrix, pollinateFlowers);
                        return;
                    }
                    else
                    {
                        matrix[beePositionRow, beePositionColum] = '.';
                        beePositionRow++;
                        if (matrix[beePositionRow, beePositionColum] == 'f')
                        {
                            matrix[beePositionRow, beePositionColum] = 'B';
                            pollinateFlowers++;
                        }
                        else if (matrix[beePositionRow, beePositionColum] == '.')
                        {
                            matrix[beePositionRow, beePositionColum] = 'B';
                        }
                        else if (matrix[beePositionRow, beePositionColum] == 'O')
                        {
                            matrix[beePositionRow, beePositionColum] = '.';

                            if (beePositionRow + 1 == n)
                            {
                                matrix[beePositionRow, beePositionColum] = '.';
                                action(matrix, pollinateFlowers);
                                return;
                            }
                            else
                            {
                                beePositionRow++;
                                if (matrix[beePositionRow, beePositionColum] == 'f')
                                {
                                    matrix[beePositionRow, beePositionColum] = 'B';
                                    pollinateFlowers++;
                                }
                                else if (matrix[beePositionRow, beePositionColum] == '.')
                                {
                                    matrix[beePositionRow, beePositionColum] = 'B';
                                }
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            if (pollinateFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinateFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinateFlowers} flowers more");
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
