using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public struct AccountId
    {
        public static AccountId From(long value)
        {
            return new AccountId(value);
        }

        private AccountId(long value)
        {
            Value = value;
        }

        public long Value { get; }
    }
}
