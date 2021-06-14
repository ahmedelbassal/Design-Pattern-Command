using CommandDesignPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPattern.Entites
{
    class BankAccountCommand : ICommands
    {
        private BankAccount _BankAccount;

        private Action _Action;

        private double _amount;

        private bool _Succeeded;

        public enum Action
        {
            WithDraw,Deposite
        }

        private double Amount;

        public BankAccountCommand(BankAccount BankAccount,Action action,double amount)
        {
            _BankAccount = BankAccount ?? throw new ArgumentNullException(paramName:"Bank Account");
            _Action = action;
            _amount = amount;
        }

        public void Call()
        {
            switch (_Action)
            {
                case Action.WithDraw:
                   _Succeeded= _BankAccount.WithDraw(_amount);
                    break;
                case Action.Deposite:
                    _BankAccount.Deposite(_amount);
                    _Succeeded = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    
            }
        }

        public void Undo()
        {
            if (!_Succeeded) return;

            Console.WriteLine("\nUndo action fired");

            switch (_Action)
            {
                case Action.WithDraw:
                    _BankAccount.Deposite(_amount);
                    break;
                case Action.Deposite:
                    _BankAccount.WithDraw(_amount);
                    break;
            }
        }
    }
}