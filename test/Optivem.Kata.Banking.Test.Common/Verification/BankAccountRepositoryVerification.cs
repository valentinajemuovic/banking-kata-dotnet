using System;
using System.Threading.Tasks;
using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using static Optivem.Kata.Banking.Test.Common.Builders.Entities.BankAccountTestBuilder;

namespace Optivem.Kata.Banking.Test.Common.Verification
{
    public static class BankAccountRepositoryVerification
    {
        public static async Task ShouldNotContainAsync(this IBankAccountRepository repository, string accountNumber)
        {
            var retrievedBankAccount = await repository.GetAsync(AccountNumber.From(accountNumber));

            retrievedBankAccount.Should().BeNull();
        }

        public static async Task ShouldContainAsync(this IBankAccountRepository repository, BankAccount bankAccount)
        {
            var accountNumber = bankAccount.AccountNumber;

            var retrievedBankAccount = await repository.GetAsync(accountNumber);

            retrievedBankAccount.Should().BeEquivalentTo(bankAccount);
        }

        public static Task ShouldContainAsync(this IBankAccountRepository repository, 
            long accountId,
            string accountNumber,
            string firstName, 
            string lastName, 
            DateOnly openingDate,
            int balance)
        {
            var expectedBankAccount = BankAccount()
                .WithAccountId(accountId)
                .WithAccountNumber(accountNumber)
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .WithOpeningDate(openingDate)
                .WithBalance(balance)
                .Build();

            return repository.ShouldContainAsync(expectedBankAccount);
        }

        public static Task ShouldContainAsync(this IBankAccountRepository repository, string accountNumber, int balance)
        {
            var expectedBankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithBalance(balance)
                .Build();

            return repository.ShouldContainAsync(expectedBankAccount);
        }
    }
}