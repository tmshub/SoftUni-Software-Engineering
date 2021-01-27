using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SquareInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] squareSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = squareSize[0];
            int cols = squareSize[1];

            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Split();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = char.Parse(input[j]);
                }
            }
            List<char> equalCharSquare = new List<char>();
            int numOfequalSquares = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(col+1 == cols || row+1 == rows)
                    {
                        break;
                    }
                    else
                    {
                       equalCharSquare.Add(matrix[row, col]);
                       equalCharSquare.Add(matrix[row, col+1]);
                       
                        if (row + 1 >= rows)
                        {
                            equalCharSquare.Add(matrix[row, col]);
                            equalCharSquare.Add(matrix[row, col+1]);
                            
                        }
                        else
                        {
                            equalCharSquare.Add(matrix[row+1, col]);
                            equalCharSquare.Add(matrix[row+1, col+1]);
                            
                        }
                        if (equalCharSquare.TrueForAll(i => i.Equals(equalCharSquare.FirstOrDefault())))
                        {
                            numOfequalSquares++;
                        }
                            equalCharSquare.Clear();

                    }
                }
            }
            Console.WriteLine(numOfequalSquares);
        }
    }
}
