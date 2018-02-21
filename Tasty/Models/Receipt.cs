using System;
using System.Collections.Generic;
using System.Linq;
using Tasty.Utils;
using Tasty.Interfaces;

namespace Tasty.Models
{
    public class Receipt : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Receipt(){
            Ingredients = new List<Ingredient>();
        }

        public Receipt(int id, string name, string desc)
        {
            Id = id;
            Name = name;
            Description = desc;
            Ingredients = new List<Ingredient>();
        }

        public void AddIngredient(Ingredient ing){
            Ingredients.Add(new Ingredient(Helpers.GenerateId(Ingredients), ing.Name, ing.UnitMeasure));
        }
    }
}
