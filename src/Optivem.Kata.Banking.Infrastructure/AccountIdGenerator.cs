using IdGen;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure
{
    public class AccountIdGenerator : IAccountIdGenerator
    {
        private const int GeneratorId = 0; // TODO: VC: Move to configuration
        private readonly IdGenerator _generator;

        public AccountIdGenerator()
        {
            _generator = new IdGenerator(GeneratorId);
        }

        public AccountId Next()
        {
            var value = _generator.CreateId();
            return AccountId.From(value);
        }
    }
}
