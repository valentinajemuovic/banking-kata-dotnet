using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public class BankAccountBuilder
    {
        public static BankAccountBuilder BankAccount()
        {
            return new BankAccountBuilder();
        }

        private AccountId _accountId;
        private AccountNumber _accountNumber;
        private AccountHolderName _accountHolderName;
        private DateOnly _openingDate;
        private Balance _balance;

        public BankAccountBuilder WithAccountId(AccountId accountId)
        {
            _accountId = accountId;
            return this;
        }

        public BankAccountBuilder WithAccountNumber(AccountNumber accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }

        public BankAccountBuilder WithAccountHolderName(AccountHolderName accountHolderName)
        {
            _accountHolderName = accountHolderName;
            return this;
        }

        public BankAccountBuilder WithOpeningDate(DateOnly openingDate)
        {
            _openingDate = openingDate;
            return this;
        }

        public BankAccountBuilder WithBalance(Balance balance)
        {
            _balance = balance;
            return this;
        }

        public BankAccount Build()
        {
            return new BankAccount(_accountId, _accountNumber, _accountHolderName, _openingDate, _balance);
        }
    }
}
