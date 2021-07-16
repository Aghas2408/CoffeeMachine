using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Models.DataModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public float Water_Portion { get; set; }
        public float Sugar_Portion { get; set; }
        public float Coffee_Portion { get; set; }

    }
}
