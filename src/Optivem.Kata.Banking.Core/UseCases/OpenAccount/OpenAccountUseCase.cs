using MediatR;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Domain.Time;
using Optivem.Kata.Banking.Core.Exceptions;

namespace Optivem.Kata.Banking.Core.UseCases.OpenAccount
{
    public class OpenAccountUseCase : IRequestHandler<OpenAccountRequest, OpenAccountResponse>
    {
        private readonly IAccountIdGenerator _accountIdGenerator;
        private readonly IAccountNumberGenerator _accountNumberGenerator;
        private readonly IDateTimeService _dateTimeService;
        private readonly IBankAccountRepository _bankAccountRepository;

        public OpenAccountUseCase(IAccountIdGenerator accountIdGenerator,
            IAccountNumberGenerator accountNumberGenerator,
            IDateTimeService dateTimeService,
            IBankAccountRepository bankAccountRepository)
        {
            _accountIdGenerator = accountIdGenerator;
            _accountNumberGenerator = accountNumberGenerator;
            _dateTimeService = dateTimeService;
            _bankAccountRepository = bankAccountRepository;
        }

        public Task<OpenAccountResponse> Handle(OpenAccountRequest request, CancellationToken cancellationToken)
        {
            var accountHolderName = AccountHolderName.From(request.FirstName, request.LastName);
            var balance = Balance.From(request.Balance);

            var accountId = _accountIdGenerator.Next();
            var accountNumber = _accountNumberGenerator.Next();
            var openingDateTime = _dateTimeService.Now();
            var openingDate = DateOnly.FromDateTime(openingDateTime);

            var bankAccount = new BankAccount(accountId, accountNumber, accountHolderName, openingDate, balance);
            _bankAccountRepository.Add(bankAccount);

            var response = new OpenAccountResponse
            {
                AccountNumber = accountNumber.Value,
            };

            return Task.FromResult(response);
        }
    }
}