using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts
{
    public class FakeAccountIdGenerator : IAccountIdGenerator
    {
        // TODO: VC: Make as base class?
        private readonly FakeGenerator<AccountId> _generator;

        public FakeAccountIdGenerator()
        {
            _generator = new FakeGenerator<AccountId>();
        }

        public AccountId Next()
        {
            return _generator.Next();
        }

        public void Enqueue(AccountId accountId)
        {
            _generator.Enqueue(accountId);
        }
    }
}
