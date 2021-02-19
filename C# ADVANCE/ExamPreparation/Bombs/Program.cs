using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> bombs = new Dictionary<string, int>();
            Queue<int> bombEffect = new Queue<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            bombs.Add("Datura Bombs", 0);
            bombs.Add("Cherry Bombs", 0);
            bombs.Add("Smoke Decoy Bombs", 0);

            bool pouchIsMaked = false;

            while (bombCasing.Count > 0 && bombEffect.Count > 0)
            {
                int currentBombEffect = bombEffect.Dequeue();
                int currentBombCasing = bombCasing.Pop();
                int sum = currentBombCasing + currentBombEffect;
                if (sum != 40 || sum != 60 || sum != 120)
                {
                    while (true)
                    {
                        if (sum == 40 || sum == 60 || sum == 120)
                        {
                            break;
                        }

                        sum -= 5;
                    }
                }
                switch (sum)
                {
                    case 40:
                        bombs["Datura Bombs"]++;
                        break;
                    case 60:
                        bombs["Cherry Bombs"]++;
                        break;
                    case 120:
                        bombs["Smoke Decoy Bombs"]++;
                        break;
                }
                if (bombs["Datura Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3)
                {
                    pouchIsMaked = true;
                    break;
                }
            }

            if (pouchIsMaked)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Count > 0)
            {
                Console.Write("Bomb Effects: ");
                Console.WriteLine(string.Join(", ", bombEffect));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (bombCasing.Count>0)
            {
                Console.Write("Bomb Casings: ");
                Console.WriteLine(string.Join(", ", bombCasing));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
