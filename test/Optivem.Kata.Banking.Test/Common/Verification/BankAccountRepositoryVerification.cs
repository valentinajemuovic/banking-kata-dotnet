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
            var bankAccount = await repository.GetByAccountNumberAsync(accountNumber);

            bankAccount.Should().BeNull();
        }
    }
}
