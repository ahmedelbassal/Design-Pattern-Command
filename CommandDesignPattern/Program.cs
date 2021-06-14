using CommandDesignPattern.Entites;
using CommandDesignPattern.Interfaces;
using System;
using System.Collections.Generic;

namespace CommandDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bank = new BankAccount(10000);

            Console.WriteLine(bank);

            var commands = new List<ICommands>
            {
                new BankAccountCommand(bank, BankAccountCommand.Action.Deposite,500),
            new BankAccountCommand(bank, BankAccountCommand.Action.WithDraw, 7500)
            };

            foreach (ICommands command in commands)
            {
                command.Call();
            }

            Console.WriteLine(bank);

            foreach (ICommands command in commands)
            {
                command.Undo();
            }

            Console.WriteLine(bank);

        }
    }
}