using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using Optivem.Kata.Banking.Core.UseCases.DepositFunds;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Data;
using Optivem.Kata.Banking.Test.Common.Extensions;
using Optivem.Kata.Banking.Test.Common.Setup;
using Optivem.Kata.Banking.Test.Common.Verification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using static Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders.DepositFundsRequestBuilder;

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

            var request = DepositFundsRequest()
                .WithAccountNumber(accountNumber)
                .WithAmount(depositAmount)
                .Build();

            await _useCase.Handle(request);

            await _bankAccountRepository.ShouldContainAsync(accountNumber, expectedFinalBalance);
        }

        [Theory]
        [ClassData(typeof(NullEmptyWhitespaceStringData))]
        public async Task Should_throw_exception_given_empty_account_number(string accountNumber)
        {
            var request = DepositFundsRequest().WithAccountNumber(accountNumber).Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.AccountNumberEmpty);
        }

        [Theory]
        [ClassData(typeof(NonPositiveIntData))]
        public async Task Should_throw_exception_given_non_positive_amount(int amount)
        {
            var request = DepositFundsRequest().WithAmount(amount).Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.AmountNotPositive);
        }

        [Fact]
        public async Task Should_throw_exception_given_non_existent_account_number()
        {
            var request = DepositFundsRequest().Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.AccountNumberNotExist);
        }
    }
}
