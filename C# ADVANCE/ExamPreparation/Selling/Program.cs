using System;
using System.Collections.Generic;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int[] possition = new int[2];
            List<int> pillarsPossition = new List<int>();
            int savedMoney = 0;
            Action<char[,], int> printer = (n, m) =>
            {
                matrix[possition[0], possition[1]] = '-';
                Console.WriteLine("Bad news, you are out of the bakery.");
                Console.WriteLine($"Money: {savedMoney}");
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        Console.Write(matrix[rows, cols]);
                    }
                    Console.WriteLine();
                }
            };

            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split();

                for (int colum = 0; colum < n; colum++)
                {
                    char symbol = char.Parse(input[0][colum].ToString());

                    if (symbol == 'S')
                    {
                        possition[0] = row;
                        possition[1] = colum;
                    }
                    if (symbol == 'O')
                    {
                        pillarsPossition.Add(row);
                        pillarsPossition.Add(colum);
                    }
                    matrix[row, colum] = symbol;
                }
            }

            while (savedMoney <= 50)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (possition[0] - 1 >= 0)
                    {
                        matrix[possition[0], possition[1]] = '-';
                        possition[0] -= 1;
                        if (char.IsDigit(matrix[possition[0], possition[1]]))
                        {
                            savedMoney += int.Parse(matrix[possition[0], possition[1]].ToString());
                            matrix[possition[0], possition[1]] = 'S';
                        }
                        else if (matrix[possition[0], possition[1]] == 'O')
                        {
                            matrix[possition[0], possition[1]] = '-';
                            if (possition[0] == pillarsPossition[0] && possition[1] == pillarsPossition[1])
                            {
                                possition[0] = pillarsPossition[2];
                                possition[1] = pillarsPossition[3];
                                matrix[possition[0], possition[1]] = 'S';
                            }
                            else if (possition[0] == pillarsPossition[2] && possition[1] == pillarsPossition[3])
                            {
                                possition[0] = pillarsPossition[0];
                                possition[1] = pillarsPossition[1];
                                matrix[possition[0], possition[1]] = 'S';
                            }
                        }
                    }
                    else
                    {
                        printer(matrix, savedMoney);
                        return;
                    }
                }
                else if (command == "down")
                {
                    if (possition[0] + 1 < n)
                    {
                        matrix[possition[0], possition[1]] = '-';
                        possition[0] += 1;
                        if (char.IsDigit(matrix[possition[0], possition[1]]))
                        {
                            savedMoney += int.Parse(matrix[possition[0], possition[1]].ToString());
                            matrix[possition[0], possition[1]] = 'S';
                        }
                        else if (matrix[possition[0], possition[1]] == 'O')
                        {
                            matrix[possition[0], possition[1]] = '-';
                            if (possition[0] == pillarsPossition[0] && possition[1] == pillarsPossition[1])
                            {
                                possition[0] = pillarsPossition[2];
                                possition[1] = pillarsPossition[3];
                                matrix[possition[0], possition[1]] = 'S';
                            }
                            else if (possition[0] == pillarsPossition[2] && possition[1] == pillarsPossition[3])
                            {
                                possition[0] = pillarsPossition[0];
                                possition[1] = pillarsPossition[1];
                                matrix[possition[0], possition[1]] = 'S';
                            }
                        }
                    }
                    else
                    {
                        printer(matrix, savedMoney);
                        return;
                    }
                }
                else if (command == "left")
                {
                    if (possition[1] - 1 >= 0)
                    {
                        matrix[possition[0], possition[1]] = '-';
                        possition[1] -= 1;
                        if (char.IsDigit(matrix[possition[0], possition[1]]))
                        {
                            savedMoney += int.Parse(matrix[possition[0], possition[1]].ToString());
                            matrix[possition[0], possition[1]] = 'S';
                        }
                        else if (matrix[possition[0], possition[1]] == 'O')
                        {
                            matrix[possition[0], possition[1]] = '-';
                            if (possition[0] == pillarsPossition[0] && possition[1] == pillarsPossition[1])
                            {
                                possition[0] = pillarsPossition[2];
                                possition[1] = pillarsPossition[3];
                                matrix[possition[0], possition[1]] = 'S';
                            }
                            else if (possition[0] == pillarsPossition[2] && possition[1] == pillarsPossition[3])
                            {
                                possition[0] = pillarsPossition[0];
                                possition[1] = pillarsPossition[1];
                                matrix[possition[0], possition[1]] = 'S';
                            }
                        }
                    }
                    else
                    {
                        printer(matrix, savedMoney);
                        return;
                    }
                }
                else if (command == "right")
                {
                    if (possition[1] + 1 < n)
                    {
                        matrix[possition[0], possition[1]] = '-';
                        possition[1] += 1;
                        if (char.IsDigit(matrix[possition[0], possition[1]]))
                        {
                            savedMoney += int.Parse(matrix[possition[0], possition[1]].ToString());
                            matrix[possition[0], possition[1]] = 'S';
                        }
                        else if (matrix[possition[0], possition[1]] == 'O')
                        {
                            matrix[possition[0], possition[1]] = '-';
                            if (possition[0] == pillarsPossition[0] && possition[1] == pillarsPossition[1])
                            {
                                possition[0] = pillarsPossition[2];
                                possition[1] = pillarsPossition[3];
                                matrix[possition[0], possition[1]] = 'S';
                            }
                            else if (possition[0] == pillarsPossition[2] && possition[1] == pillarsPossition[3])
                            {
                                possition[0] = pillarsPossition[0];
                                possition[1] = pillarsPossition[1];
                                matrix[possition[0], possition[1]] = 'S';
                            }
                        }
                    }
                    else
                    {
                        printer(matrix, savedMoney);
                        return;
                    }
                }

            }


            Console.WriteLine("Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {savedMoney}");


            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    Console.Write(matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }
    }
}
