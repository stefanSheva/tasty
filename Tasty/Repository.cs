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

        public static List<Receipt> GetAllReceipts() => ListOfReceipts;
        public static List<Ingredient> GetAllIngredients() => ListOfIngredients;

        public static void AddDummyReceipts()
        {
            if(ListOfReceipts.Count() == 0){
                ListOfReceipts.Add(new Receipt(100, "Cake", "Cake with strawberry and cherry"));
                ListOfReceipts.Add(new Receipt(101, "Protein meal", "steak and fries"));   
            }
        }

        public static int AddReceipt(Receipt receipt)
        {
            var rec = new Receipt(Helpers.GenerateId(ListOfReceipts), receipt.Name, receipt.Description);
            receipt.Ingredients.ForEach(i => {
                rec.AddIngredientToReceipt(i);
                if(!ExistsInIngredientsList(i.Name))
                    AddIngredient(i.Name, i.UnitMeasure);
            });
            ListOfReceipts.Add(rec);
            return 1;
        }

        static bool ExistsInIngredientsList(string name)
        {
            return ListOfIngredients.Any(p => p.Name == name);
        }

        public static void AddDummyIngredients()
        {
            if(ListOfIngredients.Count() == 0){
                ListOfIngredients.Add(new Ingredient(1, "Sugar", Measure.Kilogram));
                ListOfIngredients.Add(new Ingredient(2, "Milk", Measure.Litar));
                ListOfIngredients.Add(new Ingredient(3, "Eggs", Measure.Kilogram));
                ListOfIngredients.Add(new Ingredient(4, "Chicken steak", Measure.Kilogram));
                ListOfIngredients.Add(new Ingredient(5, "French fries", Measure.Kilogram));    
            }
        }

        public static int AddIngredient(string name, Measure unit)
        {
            var ingredient = new Ingredient(Helpers.GenerateId(ListOfIngredients), name, unit);
            ListOfIngredients.Add(ingredient);
            return 1;
        }
    }
}
