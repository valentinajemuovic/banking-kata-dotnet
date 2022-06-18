using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Domain.Time;
using Optivem.Kata.Banking.Core.Exceptions;

namespace Optivem.Kata.Banking.Core.UseCases.OpenAccount
{
    public class OpenAccountUseCase : IUseCase<OpenAccountRequest, OpenAccountResponse>
    {
        private readonly IAccountNumberGenerator _accountNumberGenerator;
        private readonly IDateTimeService _dateTimeService;
        private readonly IBankAccountRepository _bankAccountRepository;

        public OpenAccountUseCase(IAccountNumberGenerator accountNumberGenerator,
            IDateTimeService dateTimeService,
            IBankAccountRepository bankAccountRepository)
        {
            _accountNumberGenerator = accountNumberGenerator;
            _dateTimeService = dateTimeService;
            _bankAccountRepository = bankAccountRepository;
        }

        public Task<OpenAccountResponse> HandleAsync(OpenAccountRequest request)
        {
            var accountHolderName = AccountHolderName.From(request.FirstName, request.LastName);
            var balance = Balance.From(request.Balance);

            var accountNumber = _accountNumberGenerator.Next();
            var openingDateTime = _dateTimeService.Now();
            var openingDate = DateOnly.FromDateTime(openingDateTime);

            var bankAccount = new BankAccount(accountNumber, accountHolderName, openingDate, balance);
            _bankAccountRepository.Add(bankAccount);

            var response = new OpenAccountResponse
            {
                AccountNumber = accountNumber.Value,
            };

            return Task.FromResult(response);
        }
    }
}