using Optivem.Kata.Banking.Core.Domain.Common.Guards;
using Optivem.Kata.Banking.Core.Exceptions;

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
            MoneyValue = value.GuardAgainstNegative(ValidationMessages.BalanceNegative);
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

        public Balance Add(TransactionAmount amount)
        {
            var result = MoneyValue.Add(amount.MoneyValue);
            return From(result);
        }
    }
}