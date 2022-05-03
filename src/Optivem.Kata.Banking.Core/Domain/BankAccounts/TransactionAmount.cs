using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public struct TransactionAmount
    {
        public static TransactionAmount From(Money value)
        {
            return new TransactionAmount(value);
        }

        public static TransactionAmount From(int amount)
        {
            return From(Money.From(amount));
        }

        private TransactionAmount(Money value)
        {
            if (value.IsZeroOrNegative())
            {
                throw new ValidationException(ValidationMessages.AmountNotPositive);
            }

            MoneyValue = value;
        }

        public Money MoneyValue { get; }


    }
}
