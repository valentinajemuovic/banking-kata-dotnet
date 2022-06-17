using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.DepositFunds
{
    public class DepositFundsUseCase : IVoidUseCase<DepositFundsRequest>
    {
        public Task HandleAsync(DepositFundsRequest request)
        {
            return Task.CompletedTask;
        }
    }
}
