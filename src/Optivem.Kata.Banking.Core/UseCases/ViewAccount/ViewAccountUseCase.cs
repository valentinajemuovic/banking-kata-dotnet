using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.ViewAccount
{
    public class ViewAccountUseCase : IUseCase<ViewAccountRequest, ViewAccountResponse>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public ViewAccountUseCase(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<ViewAccountResponse> HandleAsync(ViewAccountRequest request)
        {
            var accountNumber = AccountNumber.From(request.AccountNumber);
            var bankAccount = await _bankAccountRepository.GetByAccountNumberAsync(accountNumber);

            return GetResponse(bankAccount);
        }

        private ViewAccountResponse GetResponse(BankAccount bankAccount)
        {
            var fullName = bankAccount.FirstName + " " + bankAccount.LastName;

            return new ViewAccountResponse
            {
                AccountNumber = bankAccount.AccountNumber.Value,
                FullName = fullName,
                Balance = bankAccount.Balance.IntValue,
            };
        }
    }
}
