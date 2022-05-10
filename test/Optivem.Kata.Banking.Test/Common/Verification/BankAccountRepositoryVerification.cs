using System.Threading.Tasks;
using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using static Optivem.Kata.Banking.Test.Common.Builders.Entities.BankAccountBuilder;

namespace Optivem.Kata.Banking.Test.Common.Verification
{
    public static class BankAccountRepositoryVerification
    {
        public static async Task ShouldNotContainAsync(this IBankAccountRepository repository, string accountNumber)
        {
            var retrievedBankAccount = await repository.GetByAccountNumberAsync(AccountNumber.From(accountNumber));

            retrievedBankAccount.Should().BeNull();
        }

        public static async Task ShouldContainAsync(this IBankAccountRepository repository, BankAccount bankAccount)
        {
            var accountNumber = bankAccount.AccountNumber;

            var retrievedBankAccount = await repository.GetByAccountNumberAsync(accountNumber);

            retrievedBankAccount.Should().BeEquivalentTo(bankAccount);
        }

        public static Task ShouldContainAsync(this IBankAccountRepository repository, string accountNumber,
            string firstName, string lastName, int balance)
        {
            var expectedBankAccount = BankAccount()
                .AccountNumber(accountNumber)
                .FirstName(firstName)
                .LastName(lastName)
                .Balance(balance)
                .Build();

            return repository.ShouldContainAsync(expectedBankAccount);
        }

        public static Task ShouldContainAsync(this IBankAccountRepository repository, string accountNumber, int balance)
        {
            var expectedBankAccount = BankAccount()
                .AccountNumber(accountNumber)
                .Balance(balance)
                .Build();

            return repository.ShouldContainAsync(expectedBankAccount);
        }
    }
}