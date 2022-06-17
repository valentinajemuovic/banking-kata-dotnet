using Optivem.Kata.Banking.Core.Domain.BankAccounts;

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
            _accountNumber = DefaultAccountNumber;
            _firstName = DefaultFirstName;
            _lastName = DefaultLastName;
            _balance = DefaultBalance;
        }

        public BankAccountBuilder WithAccountNumber(string accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }

        public BankAccountBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public BankAccountBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public BankAccountBuilder WithBalance(int balance)
        {
            _balance = balance;
            return this;
        }

        public BankAccount Build()
        {
            var accountNumber = AccountNumber.From(_accountNumber);
            var accountHolderName = AccountHolderName.From(_firstName, _lastName);
            var balance = Balance.From(_balance);
            return new BankAccount(accountNumber, accountHolderName, balance);
        }
    }
}