using System;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                matrix[row] = new double[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = int.Parse(input[col]);
                }

            }


            for (int i = 0; i < rows; i++)
            {
                if (i + 1 < rows)
                {
                    if (matrix[i].Length == matrix[i + 1].Length)
                    {
                        for (int j = i; j <= i + 1; j++)
                        {
                            for (int k = 0; k < matrix[j].Length; k++)
                            {
                                matrix[j][k] *= 2;
                            }
                        }
                    }
                    else
                    {
                        for (int j = i; j <= i; j++)
                        {
                            for (int k = 0; k < matrix[j].Length; k++)
                            {
                                matrix[j][k] /= 2;
                            }
                        }
                        for (int j = i + 1; j <= i + 1; j++)
                        {
                            for (int k = 0; k < matrix[j].Length; k++)
                            {
                                matrix[j][k] /= 2;
                            }
                        }
                    }
                }
            }
            string[] inputt = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (inputt[0] != "End")
            {

                if (inputt[0] == "Add")
                {
                    int rowW = int.Parse(inputt[1]);
                    int column = int.Parse(inputt[2]);
                    int value = int.Parse(inputt[3]);

                    if (rowW >= 0 && rowW < rows && column >=0 && column < matrix[rowW].Length)
                    {
                        matrix[rowW][column] += value;
                    }
                }
                else if (inputt[0] == "Subtract")
                {
                    int rowW = int.Parse(inputt[1]);
                    int column = int.Parse(inputt[2]);
                    int value = int.Parse(inputt[3]);

                    if (rowW >= 0 && rowW < rows && column >= 0 && column < matrix[rowW].Length)
                    {
                        matrix[rowW][column] -= value;
                    }
                }
                inputt = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}





