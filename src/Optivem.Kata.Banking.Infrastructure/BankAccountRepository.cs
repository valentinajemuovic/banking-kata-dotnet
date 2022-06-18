using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure
{
    public class BankAccountRepository : IBankAccountRepository
    {
        public void Add(BankAccount bankAccount)
        {
            throw new NotImplementedException();
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
    }
}
