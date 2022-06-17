using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.DepositFunds
{
    public class DepositFundsUseCase : IVoidUseCase<DepositFundsRequest>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public DepositFundsUseCase(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(DepositFundsRequest request)
        {
            var accountNumber = AccountNumber.From(request.AccountNumber);
            var amount = TransactionAmount.From(request.Amount);

            var bankAccount = await _bankAccountRepository.GetByAccountNumberAsync(accountNumber);

            bankAccount.Deposit(amount);

            _bankAccountRepository.Update(bankAccount);
        }
    }
}
