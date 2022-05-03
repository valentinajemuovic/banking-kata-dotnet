using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<BankAccount?> GetByAccountNumberAsync(AccountNumber accountNumber)
        {
            if(!_bankAccounts.ContainsKey(accountNumber))
            {
                return Task.FromResult(NULL_ACCOUNT);
            }

            BankAccount? bankAccount = _bankAccounts[accountNumber];

            return Task.FromResult(bankAccount);
        }

        public void Add(BankAccount bankAccount)
        {
            var accountNumber = bankAccount.AccountNumber;
            var clonedBankAccount = new BankAccount(bankAccount);

            _bankAccounts.Add(accountNumber, clonedBankAccount);
        }

        public void Update(BankAccount bankAccount)
        {
            _bankAccounts[bankAccount.AccountNumber] = bankAccount;
        }
    }
}
