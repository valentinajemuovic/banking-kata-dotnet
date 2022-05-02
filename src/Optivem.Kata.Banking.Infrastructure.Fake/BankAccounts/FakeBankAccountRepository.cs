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
        public Task<BankAccount?> GetByAccountNumberAsync(string accountNumber)
        {
            BankAccount? bankAccount = null;
            return Task.FromResult(bankAccount);
        }
    }
}
