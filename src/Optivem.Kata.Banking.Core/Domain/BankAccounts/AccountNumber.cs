using Optivem.Kata.Banking.Core.Exceptions;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public struct AccountNumber
    {
        public static AccountNumber From(string? value)
        {
            return new AccountNumber(value);
        }

        private AccountNumber(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException(ValidationMessages.AccountNumberEmpty);
            }

            Value = value;
        }

        public string Value { get; }
    }
}