using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquid = new Queue<int>();
            Stack<int> ingredients = new Stack<int>();
            int bread = 25;
            int cake = 50;
            int pastry = 75;
            int fruitPie = 100;
            Dictionary<string, int> cookedFoods = new Dictionary<string, int>();

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                liquid.Enqueue(input[i]);
            }
            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                ingredients.Push(input[i]);
            }

            while (liquid.Count > 0 && ingredients.Count > 0)
            {
                int sum = liquid.Peek() + ingredients.Peek();
                int liquidNum = liquid.Peek();
                int ingredientsNum = ingredients.Peek();

                if(sum == bread || sum == cake || sum == pastry || sum == fruitPie)
                {
                    liquid.Dequeue();
                    ingredients.Pop();

                   if(sum == 25)
                    {
                        if (cookedFoods.ContainsKey("Bread"))
                        {
                            cookedFoods["Bread"]++;
                        }
                        else
                        {
                            cookedFoods.Add("Bread", 1);
                        }
                    }
                    else if (sum == 50)
                    {
                        if (cookedFoods.ContainsKey("Cake"))
                        {
                            cookedFoods["Cake"]++;
                        }
                        else
                        {
                            cookedFoods.Add("Cake", 1);
                        }
                        
                    }
                    if (sum == 75)
                    {
                        if (cookedFoods.ContainsKey("Pastry"))
                        {
                            cookedFoods["Pastry"]++;
                        }
                        else
                        {
                            cookedFoods.Add("Pastry", 1);
                        }
                    }
                   
                    if (sum == 100)
                    {
                        if (cookedFoods.ContainsKey("Fruit Pie"))
                        {
                             cookedFoods["Fruit Pie"]++;
                        }
                        else
                        {
                            cookedFoods.Add("Fruit Pie", 1);
                        }
                    }
                    
                   
                }
                else
                {
                    liquid.Dequeue();
                    ingredients.Pop();
                    ingredientsNum += 3;
                    ingredients.Push(ingredientsNum);
                }
            }
            
            if(cookedFoods.Count == 4)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                if (!cookedFoods.ContainsKey("Bread"))
                {
                    cookedFoods.Add("Bread", 0);
                }
                if (!cookedFoods.ContainsKey("Cake"))
                {
                    cookedFoods.Add("Cake", 0);
                }
                if (!cookedFoods.ContainsKey("Pastry"))
                {
                    cookedFoods.Add("Pastry", 0);
                }
                if (!cookedFoods.ContainsKey("Fruit Pie"))
                {
                    cookedFoods.Add("Fruit Pie", 0);
                }
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquid.Count > 0)
            {
                Console.Write("Liquids left: ");
                Console.WriteLine(string.Join(", ", liquid));
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Count > 0)
            {
                Console.Write("Ingredients left: ");
                Console.WriteLine(string.Join(", ", ingredients));
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var product in cookedFoods.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
        }
    }
}
