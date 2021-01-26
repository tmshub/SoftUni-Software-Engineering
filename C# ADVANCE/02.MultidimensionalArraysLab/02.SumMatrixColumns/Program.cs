using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int sum = 0;

                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }

        }

    }
}
