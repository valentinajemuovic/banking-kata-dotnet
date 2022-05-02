using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Optivem.Kata.Banking.Test.Common.Builders.Entities.BankAccountBuilder;

namespace Optivem.Kata.Banking.Test.Common.Setup
{
    public static class BankAccountRepositorySetup
    {
        public static void AlreadyContains(this IBankAccountRepository repository, string accountNumber, int balance)
        {
            var bankAccount = BankAccount()
                .AccountNumber(accountNumber)
                .Balance(balance)
                .Build();

            repository.Add(bankAccount);
        }
    }
}
