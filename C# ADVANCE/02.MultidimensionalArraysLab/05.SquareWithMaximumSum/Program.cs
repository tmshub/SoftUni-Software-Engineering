using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            //7, 1, 3, 3, 2, 1
            //1, 3, 9, 8, 5, 6
            //4, 6, 7, 9, 1, 0

            int maxSquareSum = int.MinValue;
            List<int> matrixTopDigits = new List<int>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    List<int> matrixDigits = new List<int>();
                    int sum = 0;

                    if (row+1<rows && col + 1 < cols)
                    {
                        sum += matrix[row, col];
                        matrixDigits.Add(matrix[row, col]);
                        sum += matrix[row, ++col];
                        matrixDigits.Add(matrix[row, col]);
                        if (col-1 < 0)
                        {
                            col = 0;
                        }
                        else
                        {
                            --col;
                        }
                        ++row;
                        sum += matrix[row, col];
                        matrixDigits.Add(matrix[row, col]);
                        sum += matrix[row, ++col];
                        matrixDigits.Add(matrix[row, col]);
                        --row;
                        --col;
                        
                    }
                    if (sum > maxSquareSum)
                    {
                        matrixTopDigits.Clear();
                        matrixTopDigits = matrixDigits;
                        maxSquareSum = sum;
                    }
                }
            }
            Console.WriteLine(matrixTopDigits[0]+" "+matrixTopDigits[1]);
            Console.WriteLine(matrixTopDigits[2] + " " + matrixTopDigits[3]);
            Console.WriteLine(maxSquareSum);
        }
    }
}
