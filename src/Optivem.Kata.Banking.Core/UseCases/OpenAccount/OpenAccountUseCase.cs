using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.OpenAccount
{
    public class OpenAccountUseCase : IUseCase<OpenAccountRequest, OpenAccountResponse>
    {
        private readonly IAccountNumberGenerator _accountNumberGenerator;
        private readonly IBankAccountRepository _bankAccountRepository;

        public OpenAccountUseCase(IAccountNumberGenerator accountNumberGenerator, IBankAccountRepository bankAccountRepository)
        {
            _accountNumberGenerator = accountNumberGenerator;
            _bankAccountRepository = bankAccountRepository;
        }

        public Task<OpenAccountResponse> HandleAsync(OpenAccountRequest request)
        {
            if(string.IsNullOrWhiteSpace(request.FirstName))
            {
                throw new ValidationException(ValidationMessages.FirstNameEmpty);
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                throw new ValidationException(ValidationMessages.LastNameEmpty);
            }

            if(request.Balance < 0)
            {
                throw new ValidationException(ValidationMessages.BalanceNegative);
            }

            var accountNumber = _accountNumberGenerator.Next();

            var bankAccount = new BankAccount(accountNumber, request.FirstName, request.LastName, request.Balance);
            _bankAccountRepository.Add(bankAccount);

            var response = new OpenAccountResponse
            {
                AccountNumber = accountNumber.Value,
            };

            return Task.FromResult(response);
        }
    }
}
