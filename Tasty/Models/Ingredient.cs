using System;
using System.Collections.Generic;
using System.Linq;
using Tasty.Interfaces;
using static Tasty.Utils.Enum;

namespace Tasty.Models
{

    public class Ingredient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Measure UnitMeasure { get; set; } = Measure.Kilogram;

        public Ingredient(){}

        public Ingredient(int id, string name, Measure unit)
        {
            Id = id;
            Name = name;
            UnitMeasure = unit;
        }
    }
}
