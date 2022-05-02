using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.WithdrawFunds
{
    public class WithdrawFundsUseCase : IVoidUseCase<WithdrawFundsRequest>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public WithdrawFundsUseCase(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(WithdrawFundsRequest request)
        {
            var accountNumber = AccountNumber.From(request.AccountNumber);

            if(request.Amount <= 0)
            {
                throw new ValidationException(ValidationMessages.AmountNotPositive);
            }

            var bankAccount = await _bankAccountRepository.GetByAccountNumberAsync(accountNumber);

            if(bankAccount == null)
            {
                throw new ValidationException(ValidationMessages.AccountNumberNotExist);
            }

            if(bankAccount.Balance < request.Amount)
            {
                throw new ValidationException(ValidationMessages.InsufficientFunds);
            }

            bankAccount.Withdraw(request.Amount);

            _bankAccountRepository.Update(bankAccount);
        }
    }
}
