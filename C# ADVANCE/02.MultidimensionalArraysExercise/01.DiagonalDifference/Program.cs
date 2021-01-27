using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());
            int[,] squareMatrix = new int[squareSize, squareSize];
            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;

            for (int row = 0; row < squareSize; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < squareSize; col++)
                {
                    squareMatrix[row, col] = input[col];
                }
            }

            for (int row = 0; row < squareSize; row++)
            {
                for (int col = 0; col < squareSize; col++)
                {
                    if(row == col)
                    {
                        firstDiagonalSum += squareMatrix[row, col];
                        break;
                    }
                }
            }
            int count = squareMatrix.GetLength(1)-1;

            for (int row = 0; row < squareSize; row++)
            {
                for (int col = squareMatrix.GetLength(1)-1; col >= 0; col--)
                {
                    if(count == col)
                    {
                        secondDiagonalSum += squareMatrix[row, col];
                        count--;
                        break;
                    }
                }
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum-secondDiagonalSum));
        }
    }
}
