using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            List<int> maxSquare = new List<int>();
            List<int> square = new List<int>();
            int sum = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + 3 > rows || col + 3 > cols)
                    {
                        break;
                    }
                    else
                    {
                        maxSquare.Add(matrix[row, col]);
                        maxSquare.Add(matrix[row, col + 1]);
                        maxSquare.Add(matrix[row, col + 2]);
                        maxSquare.Add(matrix[row + 1, col]);
                        maxSquare.Add(matrix[row + 1, col + 1]);
                        maxSquare.Add(matrix[row + 1, col + 2]);
                        maxSquare.Add(matrix[row + 2, col]);
                        maxSquare.Add(matrix[row + 2, col + 1]);
                        maxSquare.Add(matrix[row + 2, col + 2]);
                    }

                    if (maxSquare.Sum() > maxSum)
                    {
                        square.Clear();

                        foreach (var item in maxSquare)
                        {
                            sum += item;
                            square.Add(item);
                        }

                        maxSum = sum;
                        sum = 0;
                    }

                    maxSquare.Clear();
                }
            }

            Console.WriteLine("Sum = "+maxSum);
            Console.WriteLine(square[0]+" "+square[1]+" "+square[2]);
            Console.WriteLine(square[3]+" "+square[4]+" "+square[5]);
            Console.WriteLine(square[6]+" "+square[7]+" "+square[8]);
        }
    }
}
