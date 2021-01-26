using System;

namespace _04.SymbolnMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            while (true)
            {
                for (int row = 0; row < n; row++)
                {
                    string input = Console.ReadLine();

                    if (input.Length == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                if (input[0] == matrix[i, j])
                                {
                                    Console.WriteLine($"({i}, {j})");
                                    return;
                                }
                            }
                        }

                        Console.WriteLine($"{input[0]} does not occur in the matrix");
                        return;
                    }

                    for (int col = 0; col < n; col++)
                    {
                        matrix[row, col] += input[col];
                    }
                }
            }


        }
    }
}
