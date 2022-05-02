using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Verification
{
    public static class BankAccountRepositoryVerification
    {
        public static async Task ShouldNotContainAsync(this IBankAccountRepository repository, string accountNumber)
        {
            var retrievedBankAccount = await repository.GetByAccountNumberAsync(accountNumber);

            retrievedBankAccount.Should().BeNull();
        }

        public static async Task ShouldContainAsync(this IBankAccountRepository repository, BankAccount bankAccount)
        {
            var accountNumber = bankAccount.AccountNumber;
            var retrievedBankAccount = await repository.GetByAccountNumberAsync(accountNumber);
            retrievedBankAccount.Should().BeEquivalentTo(bankAccount);
        }
    }
}
