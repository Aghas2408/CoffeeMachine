using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    abstract class ConsoleHost
    {
        static public void Run()
        {
            Console.WriteLine("Hello, you can use 50, 100, 200, 500 coins (Multiple coins can be entered).");
            Console.WriteLine("To choose coffee enter q");
            while (true)
            {
                var coin = Console.ReadLine();
                if (coin == "q")
                    break;
                if (Validator.testCoin(coin))
                    CoffeeMachine.DepositeCoin(Int32.Parse(coin));
                Console.WriteLine("Your Balance is {0}", CoffeeMachine.Balance);

            }

            while (true)
            {
                Console.WriteLine("Please choose coffee number");
                
                var coffee_id = Console.ReadLine();
                if (Validator.testCoffeeId(coffee_id))
                {
                    using (CoffeeMachineContext db = new CoffeeMachineContext())
                    {
                        var coffeeToGet = db.Products.Find(Int32.Parse(coffee_id));

                        if (coffeeToGet == null)
                        {
                            //TODO
                        }
                        if (coffeeToGet.Price > CoffeeMachine.Balance)
                        {
                            Console.WriteLine("Your product can't be ordered , because of  balance shortage");
                        }

                        var ingredients = db.Ingredients.Find(CoffeeMachine.coffeeMachineId);
                        if ((ingredients.Water >= coffeeToGet.Water_Portion * CoffeeMachine.coffeeCupVolume) &&
                            (ingredients.Sugar >= coffeeToGet.Sugar_Portion * CoffeeMachine.coffeeCupVolume) &&
                            (ingredients.Coffee >= coffeeToGet.Coffee_Portion * CoffeeMachine.coffeeCupVolume))
                        {
                            ingredients.Water -= coffeeToGet.Water_Portion * CoffeeMachine.coffeeCupVolume;
                            ingredients.Sugar -= coffeeToGet.Sugar_Portion * CoffeeMachine.coffeeCupVolume;
                            ingredients.Coffee -= coffeeToGet.Coffee_Portion * CoffeeMachine.coffeeCupVolume;
                            db.Update(ingredients);
                            db.SaveChanges();
                            CoffeeMachine.Balance -= coffeeToGet.Price;
                            Console.WriteLine("Your Balance is {0}", CoffeeMachine.Balance);
                            Console.WriteLine("Product is ready");
                            Console.WriteLine("Please enter 0");
                            if (CoffeeMachine.Balance == 0)
                            {
                                break;
                            }
                            var check_end = false;
                            while (true)
                            {
                                var button = Console.ReadLine();
                                if (button == "0")
                                {

                                    Console.WriteLine("Please enter 1 to get your change");
                                    Console.WriteLine("Please enter 2 to choose coffee");
                                    var input = Console.ReadLine();
                                    if (input == "1")
                                    {

                                        CoffeeMachine.Balance = 0;
                                        Console.WriteLine("Please take  your change");
                                        Console.WriteLine("Your Balance is {0}", CoffeeMachine.Balance);
                                        check_end = true;
                                        break;
                                    }
                                    else if (input == "2")
                                    {
                                        Run();
                                        check_end = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Wrong button");
                                }
                            }
                            if (check_end == true)
                            {
                                Console.Clear();
                                break;
                            }


                        }
                        else
                        {
                            Console.WriteLine("There are not enough  ingredients in the coffee machine");
                            CoffeeMachine.Balance = 0;
                            Console.WriteLine("Please take back your cash");
                        }

                    }
                   
                }
              
            }
        }
    }
}
