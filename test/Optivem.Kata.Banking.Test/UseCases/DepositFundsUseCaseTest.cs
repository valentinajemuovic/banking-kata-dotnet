using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.UseCases.DepositFunds;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Setup;
using Optivem.Kata.Banking.Test.Common.Verification;
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
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly DepositFundsUseCase _useCase; 

        public DepositFundsUseCaseTest()
        {
            _bankAccountRepository = new FakeBankAccountRepository();
            _useCase = new DepositFundsUseCase(_bankAccountRepository);
        }

        [Fact]
        public async Task Should_deposit_funds_given_valid_request()
        {
            string accountNumber = "GB41OMQP68570038161775";
            int initialBalance = 0;
            int depositAmount = 50;
            int expectedFinalBalance = 50;

            _bankAccountRepository.AlreadyContains(accountNumber, initialBalance);

            var request = new DepositFundsRequest();
            request.AccountNumber = accountNumber;
            request.Amount = depositAmount;

            await _useCase.HandleAsync(request);

            await _bankAccountRepository.ShouldContainAsync(accountNumber, expectedFinalBalance);
        }
    }
}
