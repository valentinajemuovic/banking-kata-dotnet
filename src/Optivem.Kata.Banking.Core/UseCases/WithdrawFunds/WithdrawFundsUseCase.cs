using MediatR;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;

namespace Optivem.Kata.Banking.Core.UseCases.WithdrawFunds
{
    public class WithdrawFundsUseCase : IRequestHandler<WithdrawFundsRequest, VoidResponse>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public WithdrawFundsUseCase(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<VoidResponse> Handle(WithdrawFundsRequest request, CancellationToken cancellationToken)
        {
            var accountNumber = AccountNumber.From(request.AccountNumber);
            var amount = TransactionAmount.From(request.Amount);

            var bankAccount = await _bankAccountRepository.GetAsync(accountNumber);

            if (bankAccount == null)
            {
                throw new ValidationException(ValidationMessages.AccountNumberNotExist);
            }

            bankAccount.Withdraw(amount);

            _bankAccountRepository.Update(bankAccount);

            return VoidResponse.Empty;
        }
    }
}