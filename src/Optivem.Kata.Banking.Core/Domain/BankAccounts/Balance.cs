using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public struct Balance
    {
        public static Balance From(Money value)
        {
            return new Balance(value);
        }

        public static Balance From(int value)
        {
            return From(Money.From(value));
        }

        private Balance(Money value)
        {
            MoneyValue = value;
        }

        public Money MoneyValue { get; }

        public int IntValue => MoneyValue.IntValue;
    }
}
