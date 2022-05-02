using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Builders.Entities
{
    internal class BankAccountBuilder
    {
        private const string DefaultAccountNumber = "GB10BARC20040184197751";
        private const string DefaultFirstName = "John";
        private const string DefaultLastName = "Smith";
        private const int DefaultBalance = 100;

        public static BankAccountBuilder BankAccount()
        {
            return new BankAccountBuilder();
        }

        private string _accountNumber;
        private string _firstName;
        private string _lastName;
        private int _balance;

        public BankAccountBuilder()
        {
            AccountNumber(DefaultAccountNumber);
            FirstName(DefaultFirstName);
            LastName(DefaultLastName);
            Balance(DefaultBalance);
        }

        public BankAccountBuilder AccountNumber(string accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }

        public BankAccountBuilder FirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public BankAccountBuilder LastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public BankAccountBuilder Balance(int balance)
        {
            _balance = balance;
            return this;
        }

        public BankAccount Build()
        {
            var accountNumber = Core.Domain.BankAccounts.AccountNumber.From(_accountNumber);
            var balance = Core.Domain.BankAccounts.Money.From(_balance);
            return new BankAccount(accountNumber, _firstName, _lastName, balance);
        }

    }
}
