using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = new string[rows, cols];
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            while (input[0]!="END")
            {
                
                if(input[0] == "swap" && input.Length == 5)
                {
                    int firstCordinatesLeft = int.Parse(input[1]);
                    int firstCordinatesRight = int.Parse(input[2]);
                    int secondCordinatesLeft = int.Parse(input[3]);
                    int secondCordinatesRight = int.Parse(input[4]);

                    if (firstCordinatesLeft < rows && firstCordinatesRight < cols
                        && secondCordinatesLeft < rows && secondCordinatesRight < cols)
                    {

                        string firstElement = matrix[firstCordinatesLeft, firstCordinatesRight];
                        string secondElement = matrix[secondCordinatesLeft, secondCordinatesRight];
                        matrix[firstCordinatesLeft, firstCordinatesRight] = secondElement;
                        matrix[secondCordinatesLeft, secondCordinatesRight] = firstElement;

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write(matrix[row,col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    if(count < rows ) 
                    {
                        count++;

                        for (int row = count-1; row < count; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                matrix[row, col] = input[col];
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
