using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
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

        [Fact]
        public void Should_throw_exception_given_empty_account_id()
        {
            Action action = () => GetDefaultBuilder()
                .WithAccountId(default(AccountId))
                .Build();

            action.Should().Throw<ValidationException>()
                .WithMessage(ValidationMessages.AccountIdEmpty);
        }

        private BankAccountBuilder GetDefaultBuilder()
        {
            var accountId = AccountId.From(BankAccountDefaults.DefaultAccountId);
            var accountNumber = AccountNumber.From(BankAccountDefaults.DefaultAccountNumber);
            var accountHolderName = AccountHolderName.From(BankAccountDefaults.DefaultFirstName, BankAccountDefaults.DefaultLastName);
            var openingDate = BankAccountDefaults.DefaultOpeningDate;
            var balance = Balance.From(BankAccountDefaults.DefaultBalance);

            return BankAccountBuilder.BankAccount()
                .WithAccountId(accountId)
                .WithAccountNumber(accountNumber)
                .WithAccountHolderName(accountHolderName)
                .WithOpeningDate(openingDate)
                .WithBalance(balance);
        }


    }
}
