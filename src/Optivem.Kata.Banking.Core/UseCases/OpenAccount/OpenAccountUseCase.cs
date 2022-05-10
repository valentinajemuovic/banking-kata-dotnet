using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;

namespace Optivem.Kata.Banking.Core.UseCases.OpenAccount
{
    public class OpenAccountUseCase : IUseCase<OpenAccountRequest, OpenAccountResponse>
    {
        private readonly IAccountNumberGenerator _accountNumberGenerator;
        private readonly IBankAccountRepository _bankAccountRepository;

        public OpenAccountUseCase(IAccountNumberGenerator accountNumberGenerator,
            IBankAccountRepository bankAccountRepository)
        {
            _accountNumberGenerator = accountNumberGenerator;
            _bankAccountRepository = bankAccountRepository;
        }

        public Task<OpenAccountResponse> HandleAsync(OpenAccountRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                throw new ValidationException(ValidationMessages.FirstNameEmpty);
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                throw new ValidationException(ValidationMessages.LastNameEmpty);
            }

            var balance = Balance.From(request.Balance);

            var accountNumber = _accountNumberGenerator.Next();


            var bankAccount = new BankAccount(accountNumber, request.FirstName, request.LastName, balance);
            _bankAccountRepository.Add(bankAccount);

            var response = new OpenAccountResponse
            {
                AccountNumber = accountNumber.Value,
            };

            return Task.FromResult(response);
        }
    }
}