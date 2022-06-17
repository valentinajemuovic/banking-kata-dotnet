using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using static Optivem.Kata.Banking.Test.Common.Builders.Entities.BankAccountBuilder;

namespace Optivem.Kata.Banking.Test.Common.Setup
{
    internal static class BankAccountRepositorySetup
    {
        public static void AlreadyContains(this IBankAccountRepository repository, string accountNumber, int balance)
        {
            var bankAccount = BankAccount()
                .AccountNumber(accountNumber)
                .Balance(balance)
                .Build();

            repository.Add(bankAccount);
        }

        public static void AlreadyContains(this IBankAccountRepository repository, string accountNumber, string firstName, string lastName, int balance)
        {
            var bankAccount = BankAccount()
                .AccountNumber(accountNumber)
                .FirstName(firstName)
                .LastName(lastName)
                .Balance(balance)
                .Build();

            repository.Add(bankAccount);
        }
    }
}