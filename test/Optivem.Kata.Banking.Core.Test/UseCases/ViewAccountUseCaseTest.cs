using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using Optivem.Kata.Banking.Core.UseCases.ViewAccount;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders;
using Optivem.Kata.Banking.Test.Common.Data;
using Optivem.Kata.Banking.Test.Common.Extensions;
using Optivem.Kata.Banking.Test.Common.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using static Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders.ViewAccountRequestBuilder;

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
            var firstName = "Kelly";
            var lastName = "McDonald";
            var balance = 400;
            var fullName = "Kelly McDonald";

            _bankAccountRepository.AlreadyContains(accountNumber, firstName, lastName, balance);

            var request = ViewAccount()
                .WithAccountNumber(accountNumber)
                .Build();

            var expectedResponse = new ViewAccountResponse
            {
                AccountNumber = accountNumber,
                FullName = fullName,
                Balance = balance,
            };

            var response = await _useCase.Handle(request);

            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Theory]
        [ClassData(typeof(NullEmptyWhitespaceStringData))]
        public async Task Should_throw_exception_given_empty_account_number(string accountNumber)
        {
            var request = ViewAccount().WithAccountNumber(accountNumber).Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.AccountNumberEmpty);
        }

        [Fact]
        public async Task Should_throw_exception_given_non_existent_account_number()
        {
            var request = ViewAccount().Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.AccountNumberNotExist);
        }
    }
}
