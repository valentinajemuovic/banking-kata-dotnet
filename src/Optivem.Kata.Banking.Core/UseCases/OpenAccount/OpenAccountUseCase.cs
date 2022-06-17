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
            var accountHolderName = AccountHolderName.From(request.FirstName, request.LastName);
            var balance = Balance.From(request.Balance);

            var accountNumber = _accountNumberGenerator.Next();

            var bankAccount = new BankAccount(accountNumber, accountHolderName, balance);
            _bankAccountRepository.Add(bankAccount);

            var response = new OpenAccountResponse
            {
                AccountNumber = accountNumber.Value,
            };

            return Task.FromResult(response);
        }
    }
}