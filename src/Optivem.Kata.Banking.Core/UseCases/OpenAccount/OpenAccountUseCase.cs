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
        private IAccountNumberGenerator accountNumberGenerator;

        public OpenAccountUseCase(IAccountNumberGenerator accountNumberGenerator)
        {
            this.accountNumberGenerator = accountNumberGenerator;
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

            throw new NotImplementedException();
        }
    }
}
