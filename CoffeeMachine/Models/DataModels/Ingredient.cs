using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Models.DataModels
{
    public class Ingredient
    {
        public int Id { get; set; }
        public float Water { get; set; }
        public float Sugar { get; set; }
        public float Coffee { get; set; }
    }
}
