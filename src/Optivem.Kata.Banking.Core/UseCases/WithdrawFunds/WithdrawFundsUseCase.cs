using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.WithdrawFunds
{
    public class WithdrawFundsUseCase : IVoidUseCase<WithdrawFundsRequest>
    {
        public Task HandleAsync(WithdrawFundsRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.AccountNumber))
            {
                throw new ValidationException(ValidationMessages.AccountNumberEmpty);
            }

            throw new NotImplementedException();
        }
    }
}
