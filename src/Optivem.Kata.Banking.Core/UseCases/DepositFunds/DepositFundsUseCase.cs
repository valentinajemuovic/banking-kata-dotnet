using MediatR;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.DepositFunds
{
    public class DepositFundsUseCase : IRequestHandler<DepositFundsRequest, VoidResponse>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public DepositFundsUseCase(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<VoidResponse> Handle(DepositFundsRequest request, CancellationToken cancellationToken)
        {
            var accountNumber = AccountNumber.From(request.AccountNumber);
            var amount = TransactionAmount.From(request.Amount);

            var bankAccount = await _bankAccountRepository.GetAsync(accountNumber);

            if (bankAccount == null)
            {
                throw new ValidationException(ValidationMessages.AccountNumberNotExist);
            }

            bankAccount.Deposit(amount);

            _bankAccountRepository.Update(bankAccount);

            return VoidResponse.Empty;
        }
    }
}
