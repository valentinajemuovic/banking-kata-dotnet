using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public struct Money
    {
        public Money(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public Money Subtract(Money money)
        {
            var result = Value - money.Value;
            return From(result);
        }

        public bool IsNegative()
        {
            return Value < 0;
        }

        public bool IsZeroOrNegative()
        {
            return Value <= 0;
        }

        public static Money From(int value)
        {
            return new Money(value);
        }

        public bool IsLessThan(Money other)
        {
            return Value < other.Value;
        }
    }
}
