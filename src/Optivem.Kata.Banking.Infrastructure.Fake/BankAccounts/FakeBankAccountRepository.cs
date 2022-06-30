using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;

namespace Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts
{
    public class FakeBankAccountRepository : IBankAccountRepository
    {
        private static readonly BankAccount? NULL_ACCOUNT = null;

        private readonly Dictionary<AccountNumber, BankAccount> _bankAccounts;

        public FakeBankAccountRepository()
        {
            _bankAccounts = new Dictionary<AccountNumber, BankAccount>();
        }

        public Task<BankAccount?> GetAsync(AccountNumber accountNumber)
        {
            if (!Contains(accountNumber))
            {
                return Task.FromResult(NULL_ACCOUNT);
            }

            BankAccount bankAccount = _bankAccounts[accountNumber];

            var clonedBankAccount = new BankAccount(bankAccount);

            return Task.FromResult(clonedBankAccount);
        }

        public void Add(BankAccount bankAccount)
        {
            var accountNumber = bankAccount.AccountNumber;

            if (Contains(accountNumber))
            {
                throw new RepositoryException(RepositoryMessages.RepositoryConstraintValidation);
            }


            var clonedBankAccount = new BankAccount(bankAccount);

            _bankAccounts.Add(accountNumber, clonedBankAccount);
        }

        public void Update(BankAccount bankAccount)
        {
            var accountNumber = bankAccount.AccountNumber;

            if (!Contains(accountNumber))
            {
                throw new RepositoryException(RepositoryMessages.RepositoryCannotUpdateNonExistent);
            }

            var clonedBankAccount = new BankAccount(bankAccount);

            _bankAccounts[accountNumber] = clonedBankAccount;
        }

        private bool Contains(AccountNumber accountNumber)
        {
            return _bankAccounts.ContainsKey(accountNumber);
        }
    }
}