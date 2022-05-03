using Optivem.Kata.Banking.Core.Exceptions;
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
            if (value.IsNegative())
            {
                throw new ValidationException(ValidationMessages.BalanceNegative);
            }

            MoneyValue = value;
        }

        public Money MoneyValue { get; }

        public int IntValue => MoneyValue.IntValue;

        public bool IsLessThan(TransactionAmount amount)
        {
            return MoneyValue.IsLessThan(amount.MoneyValue);
        }

        public Balance Subtract(TransactionAmount amount)
        {
            var result = MoneyValue.Subtract(amount.MoneyValue);
            return From(result);
        }
    }
}
