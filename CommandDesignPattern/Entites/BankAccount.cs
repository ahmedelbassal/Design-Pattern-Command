using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPattern.Entites
{
    class BankAccount
    {
        private double _Balance;
        private double _WithDrawLimit;

        public BankAccount(double Balance)
        {
            _Balance = Balance;
        }

        public void Deposite(double amount)
        {
            _Balance += amount;
            Console.WriteLine($"You deposited {amount} L.E successfully Your current balance is {_Balance} L.E");
        }

        public bool WithDraw(double amount)
        {
            if (_Balance - amount >= _WithDrawLimit)
            {
                _Balance -= amount;
                Console.WriteLine($"You Withdrawed {amount} L.E successfully Your current balance is {_Balance} L.E");
                return true;
                   
            }
            else
            {
                Console.WriteLine("Your balance is not enough");
                return false;
            }
        }


        public override string ToString()
        {
            return $"Balance : {_Balance} L.E"; 
        }
    }
}
