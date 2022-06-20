using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly DatabaseContext _dbContext;

        public BankAccountRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(BankAccount bankAccount)
        {
            var record = Create(bankAccount);
            _dbContext.Add(record);
            _dbContext.SaveChanges();
        }

        public Task<BankAccount?> GetByAccountNumberAsync(AccountNumber accountNumber)
        {
            var bankAccount = (BankAccount?) null;
            return Task.FromResult(bankAccount);
        }

        public void Update(BankAccount bankAccount)
        {
            throw new NotImplementedException();
        }

        private BankAccountRecord Create(BankAccount bankAccount)
        {
            return new BankAccountRecord
            {
                Id = bankAccount.AccountId.Value,
                AccountNumber = bankAccount.AccountNumber.Value,
                FirstName = bankAccount.AccountHolderName.FirstName,
                LastName = bankAccount.AccountHolderName.LastName,
                OpeningDate = bankAccount.OpeningDate.ToDateTime(TimeOnly.MinValue),
                Balance = bankAccount.Balance.IntValue,
            };
        }
    }
}
