using MediatR;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.ViewAccount
{
    public class ViewAccountUseCase : IRequestHandler<ViewAccountRequest, ViewAccountResponse>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public ViewAccountUseCase(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<ViewAccountResponse> Handle(ViewAccountRequest request, CancellationToken cancellationToken)
        {
            var accountNumber = AccountNumber.From(request.AccountNumber);
            var bankAccount = await _bankAccountRepository.GetAsync(accountNumber);

            if (bankAccount == null)
            {
                throw new ValidationException(ValidationMessages.AccountNumberNotExist);
            }

            return GetResponse(bankAccount);
        }

        private ViewAccountResponse GetResponse(BankAccount bankAccount)
        {
            var fullName = bankAccount.AccountHolderName.GetFullName();

            return new ViewAccountResponse
            {
                AccountNumber = bankAccount.AccountNumber.Value,
                FullName = fullName,
                Balance = bankAccount.Balance.IntValue,
            };
        }
    }
}
