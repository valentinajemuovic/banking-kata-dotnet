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

        public static BankAccountBuilder BankAccount()
        {
            return new BankAccountBuilder();
        }

        private string _accountNumber;

        public BankAccountBuilder()
        {
            AccountNumber(DefaultAccountNumber);
        }

        public BankAccountBuilder AccountNumber(String accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }

        public BankAccount Build()
        {
            return new BankAccount(_accountNumber);
        }

    }
}
