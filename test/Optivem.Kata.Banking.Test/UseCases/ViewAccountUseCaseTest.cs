using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.UseCases.ViewAccount;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders;
using Optivem.Kata.Banking.Test.Common.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.UseCases
{
    public class ViewAccountUseCaseTest
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ViewAccountUseCase _useCase;

        public ViewAccountUseCaseTest()
        {
            _bankAccountRepository = new FakeBankAccountRepository();
            _useCase = new ViewAccountUseCase(_bankAccountRepository);
        }

        [Fact]
        public async Task Should_view_account_given_valid_request()
        {
            var accountNumber = "GB36BMFK75394735916876";
            var balance = 100;

            _bankAccountRepository.AlreadyContains(accountNumber, balance);

            var request = ViewAccountRequestBuilder.ViewAccount()
                .AccountNumber(accountNumber)
                .Build();

            var expectedResponse = new ViewAccountResponse
            {
                AccountNumber = accountNumber,
            };

            var response = await _useCase.HandleAsync(request);

            response.Should().BeEquivalentTo(expectedResponse);
        }

        /*
         * 
        expectedResponse.setAccountNumber("3223fsfds");
        expectedResponse.setFullName(fullName);
        expectedResponse.setBalance(initialBalance);
         * 
         */
    }
}
