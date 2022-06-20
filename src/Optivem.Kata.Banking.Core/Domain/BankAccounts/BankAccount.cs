using Optivem.Kata.Banking.Core.Domain.Common.Guards;
using Optivem.Kata.Banking.Core.Exceptions;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public class BankAccount
    {
        public BankAccount(AccountId accountId, AccountNumber accountNumber, AccountHolderName accountHolderName, DateOnly openingDate, Balance balance)
        {
            AccountId = accountId.GuardAgainstEmpty(ValidationMessages.AccountIdEmpty);
            AccountNumber = accountNumber.GuardAgainstEmpty(ValidationMessages.AccountNumberEmpty);
            AccountHolderName = accountHolderName.GuardAgainstEmpty(ValidationMessages.AccountHolderNameEmpty);
            OpeningDate = openingDate.GuardAgainstEmpty(ValidationMessages.OpeningDateEmpty);
            Balance = balance;
        }

        public BankAccount(BankAccount other)
            : this(other.AccountId, other.AccountNumber, other.AccountHolderName, other.OpeningDate, other.Balance)
        {
        }

        public AccountId AccountId { get; }
        public AccountNumber AccountNumber { get; }
        public AccountHolderName AccountHolderName { get; }
        public DateOnly OpeningDate { get; }
        public Balance Balance { get; private set; }

        public void Withdraw(TransactionAmount amount)
        {
            Guard.Against(() => Balance.IsLessThan(amount), ValidationMessages.InsufficientFunds);

            Balance = Balance.Subtract(amount);
        }

        public void Deposit(TransactionAmount amount)
        {
            Balance = Balance.Add(amount);
        }
    }
}