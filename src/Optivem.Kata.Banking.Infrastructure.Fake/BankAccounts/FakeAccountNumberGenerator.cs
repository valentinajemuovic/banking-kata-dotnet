using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.Common;
using Optivem.Kata.Banking.Infrastructure.Fake.Exceptions;

namespace Optivem.Kata.Banking.Infrastructure.Fake.Generators
{
    public class FakeAccountNumberGenerator : IAccountNumberGenerator
    {
        private readonly FakeGenerator<AccountNumber> _generator;

        public FakeAccountNumberGenerator()
        {
            _generator = new FakeGenerator<AccountNumber>();
        }

        public AccountNumber Next()
        {
            return _generator.Next();
        }

        public void Enqueue(AccountNumber accountNumber)
        {
            _generator.Enqueue(accountNumber);
        }
    }
}