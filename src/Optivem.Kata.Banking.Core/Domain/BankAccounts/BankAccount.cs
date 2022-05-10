using Optivem.Kata.Banking.Core.Exceptions;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public class BankAccount
    {
        public BankAccount(AccountNumber accountNumber, string firstName, string lastName, Balance balance)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public BankAccount(BankAccount other)
            : this(other.AccountNumber, other.FirstName, other.LastName, other.Balance)
        {
        }

        public AccountNumber AccountNumber { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public Balance Balance { get; private set; }

        public void Withdraw(TransactionAmount amount)
        {
            if (Balance.IsLessThan(amount))
            {
                throw new ValidationException(ValidationMessages.InsufficientFunds);
            }

            Balance = Balance.Subtract(amount);
        }
    }
}