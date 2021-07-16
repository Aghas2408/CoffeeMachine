using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    class CoffeeMachine
    {
        public static int coffeeMachineId = 1;
        public static int coffeeCupVolume = 200;

        private static  int balance;
        public static int Balance { get { return balance; } set { balance = value; } }
        public  static void DepositeCoin(int money)
        {
            switch (money)
            {
                case (50):
                    Balance += 50;
                    break;
                case (100):
                    Balance += 100;
                    break;
                case (200):
                    Balance += 200;
                    break;
                case (500):
                    Balance += 500;
                    break;
            }
        }
    }
}
