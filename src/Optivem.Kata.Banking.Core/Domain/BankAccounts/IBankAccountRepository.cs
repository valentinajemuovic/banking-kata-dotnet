using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public interface IBankAccountRepository
    {
        public Task<BankAccount?> GetByAccountNumberAsync(string accountNumber);

        public void Add(BankAccount bankAccount);
    }
}
