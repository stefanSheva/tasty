using System;
using System.Collections.Generic;
using System.Linq;
using Tasty.Models;
using Tasty.Utils;
using static Tasty.Utils.Enum;

namespace Tasty
{
    public class Repository
    {
        public static List<Receipt> ListOfReceipts = new List<Receipt>();
        public static List<Ingredient> ListOfIngredients = new List<Ingredient>();

        public Repository()
        {
        }

        public static void AddDummyReceipts()
        {
            ListOfReceipts.Add(new Receipt(100, "Cake", "Cake with strawberry and cherry"));
            ListOfReceipts.Add(new Receipt(101, "Protein meal", "steak and fries"));
        }

        public static int AddReceipt(Receipt receipt)
        {
            var rec = new Receipt(Helpers.GenerateId(ListOfReceipts), receipt.Name, receipt.Description);
            receipt.Ingredients.ForEach(i => rec.AddIngredient(i));
            ListOfReceipts.Add(rec);
            return 1;
        }

        public static void AddDummyIngredients()
        {
            ListOfIngredients.Add(new Ingredient(1, "Sugar", Measure.Kilogram));
            ListOfIngredients.Add(new Ingredient(2, "Milk", Measure.Litar));
            ListOfIngredients.Add(new Ingredient(3, "Eggs", Measure.Kilogram));
            ListOfIngredients.Add(new Ingredient(4, "Chicken steak", Measure.Kilogram));
            ListOfIngredients.Add(new Ingredient(5, "French fries", Measure.Kilogram));
        }

        public static int AddIngredient(string name, Measure unit)
        {
            var ingredient = new Ingredient(Helpers.GenerateId(ListOfIngredients), name, unit);
            ListOfIngredients.Add(ingredient);
            return 1;
        }
    }
}
