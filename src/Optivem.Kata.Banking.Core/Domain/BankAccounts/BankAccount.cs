using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public class BankAccount
    {
        public BankAccount(AccountNumber accountNumber, string firstName, string lastName, Money balance)
        {
            if (balance.IsNegative())
            {
                throw new ValidationException(ValidationMessages.BalanceNegative);
            }

            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public AccountNumber AccountNumber { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public Money Balance { get; private set; }

        public void Withdraw(Money amount)
        {
            if (amount.IsZeroOrNegative())
            {
                throw new ValidationException(ValidationMessages.AmountNotPositive);
            }

            if (Balance.IsLessThan(amount))
            {
                throw new ValidationException(ValidationMessages.InsufficientFunds);
            }

            Balance = Balance.Subtract(amount);
        }
    }
}
