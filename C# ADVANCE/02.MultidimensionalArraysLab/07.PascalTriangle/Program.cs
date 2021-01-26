using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] matrix = new long[n][];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < row + 1; col++)
                {
                    if (row == 0)
                    {
                        matrix[row] = new long[1];
                        matrix[row][0] = 1;
                    }
                    else
                    {
                        matrix[row] = new long[matrix[row - 1].Length + 1];
                        matrix[row][0] = 1;

                        for (int rows = 0; rows <= 0; rows++)
                        {
                            for (int cols = 0; cols < matrix[row-1].Length; cols++)
                            {
                                if (cols + 1 < matrix[row - 1].Length)
                                {
                                    matrix[row][cols+1] = matrix[row - 1][cols] + matrix[row - 1][cols + 1];
                                }
                                else
                                {
                                    matrix[row][cols+1] = matrix[row - 1][cols] + 0;
                                   
                                }
                            }
                        }
                        col = row + 1;
                    }
                }
            }
            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    Console.Write(matrix[rows][cols]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
