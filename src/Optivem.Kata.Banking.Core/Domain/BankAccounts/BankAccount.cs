using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public class BankAccount
    {
        public BankAccount(AccountNumber accountNumber, string firstName, string lastName, int balance)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public AccountNumber AccountNumber { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Balance { get; private set; }

        public void Withdraw(int amount)
        {
            Balance -= amount;
        }
    }
}
