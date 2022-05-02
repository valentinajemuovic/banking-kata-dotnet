using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure.Fake.Generators
{
    public class FakeAccountNumberGenerator : IAccountNumberGenerator
    {
        private readonly Queue<AccountNumber> _queue;

        public FakeAccountNumberGenerator()
        {
            _queue = new Queue<AccountNumber>();
        }

        public AccountNumber Next()
        {
            if(!_queue.Any())
            {
                throw new FakeException(FakeMessages.GeneratorDoesNotHaveNext);
            }

            return _queue.Dequeue();
        }

        public void Add(AccountNumber accountNumber)
        {
            _queue.Enqueue(accountNumber);
        }
    }
}
