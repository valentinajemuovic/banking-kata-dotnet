namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public struct Money
    {
        public static Money From(int value)
        {
            return new Money(value);
        }

        private Money(int value)
        {
            IntValue = value;
        }

        public int IntValue { get; }

        public Money Subtract(Money money)
        {
            var result = IntValue - money.IntValue;
            return From(result);
        }

        public Money Add(Money money)
        {
            var result = IntValue + money.IntValue;
            return From(result);
        }

        public bool IsNegative()
        {
            return IntValue < 0;
        }

        public bool IsZeroOrNegative()
        {
            return IntValue <= 0;
        }

        public bool IsLessThan(Money other)
        {
            return IntValue < other.IntValue;
        }

    }
}