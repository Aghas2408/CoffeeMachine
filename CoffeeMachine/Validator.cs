using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class InvalidInput : Exception
    {
        public InvalidInput()
        {
            Console.WriteLine("Invalid Input. Please try again and use 50, 100, 200, 500 coins");
        }
    }
    public class InvalidIdInput : Exception
    {
        public InvalidIdInput()
        {
            Console.WriteLine("Invalid Input. Please try again and use 1-10 Id's");
        }
    }
    abstract class Validator
    {
        static public bool testCoin( dynamic coin)
        {
            try
            {
               int  result = Int32.Parse(coin);
              
               if (result != 50 && result != 100 && result != 200 && result != 500)
                    throw new InvalidInput();

                return true;
            }
            catch (InvalidInput e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please input a number");
                return false;
            }
            catch (Exception)
            {
          
                throw;

            }
           

           
        }

        static public bool testCoffeeId(string coffee_id)
        {
            try
            {
                int result = Int32.Parse(coffee_id);
                if (result < 1 || result > 10)        
                    throw new InvalidIdInput();
      
                return true;
            }
            catch (InvalidIdInput e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please input a number");
                return false;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
