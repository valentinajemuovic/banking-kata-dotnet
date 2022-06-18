using Optivem.Kata.Banking.Core.Exceptions;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public class BankAccount
    {
        public BankAccount(AccountNumber accountNumber, AccountHolderName accountHolderName, DateOnly openingDate, Balance balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            OpeningDate = openingDate;
            Balance = balance;
        }

        public BankAccount(BankAccount other)
            : this(other.AccountNumber, other.AccountHolderName, other.OpeningDate, other.Balance)
        {
        }

        public AccountNumber AccountNumber { get; }
        public AccountHolderName AccountHolderName { get; }
        public DateOnly OpeningDate { get; }
        public Balance Balance { get; private set; }

        public void Withdraw(TransactionAmount amount)
        {
            if (Balance.IsLessThan(amount))
            {
                throw new ValidationException(ValidationMessages.InsufficientFunds);
            }

            Balance = Balance.Subtract(amount);
        }

        public void Deposit(TransactionAmount amount)
        {
            Balance = Balance.Add(amount);
        }
    }
}