using System;
using System.Linq;

namespace _06.JaggetArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRowSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixRowSize][];
            string[] input = Console.ReadLine().Split();
            int count = 0;

            while (input[0] != "END")
            {
                if (input[0] == "Add")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int num = int.Parse(input[3]);

                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] += num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (input[0] == "Subtract")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int num = int.Parse(input[3]);

                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else
                {
                    matrix[count] = new int[input.Length];

                    for (int cols = 0; cols < input.Length; cols++)
                    {
                        matrix[count][cols] = int.Parse(input[cols]);
                    }

                    count++;
                }
                input = Console.ReadLine().Split();
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
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
