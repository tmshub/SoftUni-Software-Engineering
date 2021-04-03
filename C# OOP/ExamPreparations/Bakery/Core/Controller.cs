using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<BakedFood> foods;
        private List<Drink> drinks;
        private List<Table> tables;
        private decimal incomePerDay = 0;
        public Controller()
        {
            foods = new List<BakedFood>();
            drinks = new List<Drink>();
            tables = new List<Table>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink drink;
            string message = $"Added {name} ({brand}) to the drink menu";

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
                drinks.Add(drink);
                return message;
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
                drinks.Add(drink);
                return message;
            }

            return null;
        }

        public string AddFood(string type, string name, decimal price)
        {
            BakedFood bakedFood;
            string message = $"Added {name} ({type}) to the menu";

            if (type == "Cake")
            {
                bakedFood = new Cake(name, price);
                foods.Add(bakedFood);
                return message;
            }
            else if(type == "Bread")
            {
                bakedFood = new Bread(name, price);
                foods.Add(bakedFood);
                return message;
            }

            return null;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table;
            string message = $"Added table number {tableNumber} in the bakery";

            if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
                tables.Add(table);
                return message;
            }
            else if(type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
                tables.Add(table);
                return message;
            }

            return null;
        }


        public string GetFreeTablesInfo()
        {
            var currentTables = tables.Where(x => x.IsReserved == false);
            StringBuilder sb = new StringBuilder();

            foreach (var item in currentTables)
            {
                sb.AppendLine(item.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            
           return $"Total income: {incomePerDay:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {table.GetBill():f2}");
            incomePerDay += table.GetBill();
            table.Clear();
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            Drink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            BakedFood food = foods.FirstOrDefault(x => x.Name == foodName);

            if(table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if(food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            Table table = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if(table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
