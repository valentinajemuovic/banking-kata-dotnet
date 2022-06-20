using Optivem.Kata.Banking.Core.Domain.Common.Guards;
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
            Value = value.GuardAgainstNullOrWhiteSpace(ValidationMessages.AccountNumberEmpty);
        }

        public string Value { get; }
    }
}