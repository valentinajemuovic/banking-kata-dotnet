using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using static Optivem.Kata.Banking.Test.Common.Builders.Entities.BankAccountTestBuilder;

namespace Optivem.Kata.Banking.Test.Common.Setup
{
    public static class BankAccountRepositorySetup
    {
        public static void AlreadyContains(this IBankAccountRepository repository, string accountNumber, int balance)
        {
            var bankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithBalance(balance)
                .Build();

            repository.Add(bankAccount);
        }

        public static void AlreadyContains(this IBankAccountRepository repository, string accountNumber, string firstName, string lastName, int balance)
        {
            var bankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .WithBalance(balance)
                .Build();

            repository.Add(bankAccount);
        }
    }
}