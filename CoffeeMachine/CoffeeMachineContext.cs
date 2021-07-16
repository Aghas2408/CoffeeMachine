using CoffeeMachine.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class CoffeeMachineContext:DbContext
    {
        public DbSet<Ingredient>  Ingredients { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;database=CoffeeMachineDB;Trusted_Connection=True");
        }
    }
}
