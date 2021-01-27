using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfMatrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = sizeOfMatrix[0];
            int cols = sizeOfMatrix[1];
            bool isNewLine = false;

            char[,] matrix = new char[rows, cols];

            string[] splitedInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string input = splitedInput[0];
            string lastLetters = string.Empty;

            for (int i = 0; i <= rows*cols; i++)
            {
                lastLetters += input;
            }

            for (int row = 0; row < rows; row++)
            {
                if (!isNewLine)
                {
                    isNewLine = true;

                    for (int col = 0; col < cols; col++)
                    {
                        if (col == cols - 1)
                        {
                            matrix[row, col] = lastLetters[col];
                            lastLetters = lastLetters.Remove(0, col+1);
                        }
                        else
                        {
                            matrix[row, col] = lastLetters[col];
                        }
                    }
                }
                else
                {
                    isNewLine = false;
                    input = lastLetters.Substring(0, cols);
                    Queue<char> reversedElem = new Queue<char>(input);

                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (col == 0)
                        {
                            matrix[row, col] = reversedElem.Dequeue();
                            lastLetters = lastLetters.Remove(0,cols);
                        }
                        else
                        {
                            matrix[row, col] = reversedElem.Dequeue();
                        }

                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
