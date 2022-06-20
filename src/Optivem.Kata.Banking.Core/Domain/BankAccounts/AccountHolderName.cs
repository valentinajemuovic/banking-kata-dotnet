using Optivem.Kata.Banking.Core.Domain.Common.Guards;
using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public struct AccountHolderName
    {
        public static AccountHolderName From(string? firstName, string? lastName)
        {
            return new AccountHolderName(firstName, lastName);
        }

        private AccountHolderName(string? firstName, string? lastName)
        {
            FirstName = firstName.GuardAgainstNullOrWhiteSpace(ValidationMessages.FirstNameEmpty);
            LastName = lastName.GuardAgainstNullOrWhiteSpace(ValidationMessages.LastNameEmpty);
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
