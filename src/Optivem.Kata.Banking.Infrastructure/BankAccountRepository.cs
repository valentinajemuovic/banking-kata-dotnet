using Microsoft.EntityFrameworkCore;
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
            _dbContext.BankAccounts.Add(record);
            _dbContext.SaveChanges();
        }

        public async Task<BankAccount?> GetAsync(AccountNumber accountNumber)
        {
            var record = await _dbContext.BankAccounts
                .Where(e => e.AccountNumber == accountNumber.Value)
                .SingleOrDefaultAsync();

            if(record == null)
            {
                return null;
            }

            return Get(record);
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

        private BankAccount Get(BankAccountRecord record)
        {
            return BankAccountBuilder.BankAccount()
                .WithAccountId(AccountId.From(record.Id))
                .WithAccountNumber(AccountNumber.From(record.AccountNumber))
                .WithAccountHolderName(AccountHolderName.From(record.FirstName, record.LastName))
                .WithOpeningDate(DateOnly.FromDateTime(record.OpeningDate))
                .WithBalance(Balance.From(record.Balance))
                .Build();
        }
    }
}
