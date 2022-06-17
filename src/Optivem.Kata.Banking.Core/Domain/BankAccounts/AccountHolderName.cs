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
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ValidationException(ValidationMessages.FirstNameEmpty);
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ValidationException(ValidationMessages.LastNameEmpty);
            }

            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
