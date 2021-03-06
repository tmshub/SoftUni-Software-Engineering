﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                list.Add(input);
            }
            Box<int> box = new Box<int>(list);
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}
