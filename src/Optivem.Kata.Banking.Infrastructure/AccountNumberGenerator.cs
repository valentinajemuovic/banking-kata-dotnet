using NUlid;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure
{
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        public AccountNumber Next()
        {
            var value = Ulid.NewUlid().ToString();
            return AccountNumber.From(value);
        }
    }
}
