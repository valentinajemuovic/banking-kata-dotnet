using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Builders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Domain
{
    public class BankAccountTest
    {
        [Fact]
        public void Should_construct_bank_account_given_valid_data()
        {
            var bankAccount = GetDefaultBuilder().Build();

            bankAccount.Should().NotBeNull();
        }

        private BankAccountBuilder GetDefaultBuilder()
        {
            AccountNumber accountNumber = AccountNumber.From(BankAccountDefaults.DefaultAccountNumber);
            AccountHolderName accountHolderName = AccountHolderName.From(BankAccountDefaults.DefaultFirstName, BankAccountDefaults.DefaultLastName);
            DateOnly openingDate = BankAccountDefaults.DefaultOpeningDate;
            Balance balance = Balance.From(BankAccountDefaults.DefaultBalance);

            return BankAccountBuilder.BankAccount()
                .WithAccountNumber(accountNumber)
                .WithAccountHolderName(accountHolderName)
                .WithOpeningDate(openingDate)
                .WithBalance(balance);
        }
    }
}
