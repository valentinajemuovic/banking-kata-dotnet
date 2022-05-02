using Optivem.Kata.Banking.Infrastructure.Fake.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Givens
{
    public static class FakeAccountNumberGeneratorSetup
    {
        public static void WillGenerate(this FakeAccountNumberGenerator generator, string accountNumber)
        {
            generator.Add(accountNumber);
        }
    }
}
