using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Setup
{
    public static class FakeAccountIdGeneratorSetup
    {
        public static void WillGenerate(this FakeAccountIdGenerator generator, long accountId)
        {
            generator.Enqueue(AccountId.From(accountId));
        }
    }
}
