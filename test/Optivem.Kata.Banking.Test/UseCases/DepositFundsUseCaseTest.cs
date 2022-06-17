using Optivem.Kata.Banking.Core.UseCases.DepositFunds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.UseCases
{
    public class DepositFundsUseCaseTest
    {
        private readonly DepositFundsUseCase _useCase; 

        public DepositFundsUseCaseTest()
        {
            _useCase = new DepositFundsUseCase();
        }


        [Fact]
        public async void Nothing()
        {
            var request = new DepositFundsRequest();

            await _useCase.HandleAsync(request);
        }

    }
}
