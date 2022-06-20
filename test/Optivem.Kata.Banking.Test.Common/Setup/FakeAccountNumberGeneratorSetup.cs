using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.Generators;

namespace Optivem.Kata.Banking.Test.Common.Givens
{
    public static class FakeAccountNumberGeneratorSetup
    {
        public static void WillGenerate(this FakeAccountNumberGenerator generator, string accountNumber)
        {
            generator.Enqueue(AccountNumber.From(accountNumber));
        }
    }
}