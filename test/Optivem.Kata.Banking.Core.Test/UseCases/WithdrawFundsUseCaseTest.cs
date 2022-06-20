using System;
using System.Threading.Tasks;
using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using Optivem.Kata.Banking.Core.UseCases.WithdrawFunds;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Data;
using Optivem.Kata.Banking.Test.Common.Extensions;
using Optivem.Kata.Banking.Test.Common.Setup;
using Optivem.Kata.Banking.Test.Common.Verification;
using Xunit;
using static Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders.WithdrawFundsRequestBuilder;

namespace Optivem.Kata.Banking.Test.UseCases
{
    public class WithdrawFundsUseCaseTest
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly WithdrawFundsUseCase _useCase;

        public WithdrawFundsUseCaseTest()
        {
            _bankAccountRepository = new FakeBankAccountRepository();
            _useCase = new WithdrawFundsUseCase(_bankAccountRepository);
        }

        [Theory]
        [InlineData("GB10BARC20040184197751", 70, 30, 40)]
        [InlineData("GB36BMFK75394735916876", 100, 100, 0)]
        public async Task Should_withdraw_funds_given_valid_request(string accountNumber, int initialBalance,
            int amount, int expectedFinalBalance)
        {
            _bankAccountRepository.AlreadyContains(accountNumber, initialBalance);

            var request = WithdrawFundsRequest()
                .WithAccountNumber(accountNumber)
                .WithAmount(amount)
                .Build();

            await _useCase.Handle(request);

            await _bankAccountRepository.ShouldContainAsync(accountNumber, expectedFinalBalance);
        }

        [Theory]
        [ClassData(typeof(NullEmptyWhitespaceStringData))]
        public async Task Should_throw_exception_given_empty_account_number(string accountNumber)
        {
            var request = WithdrawFundsRequest().WithAccountNumber(accountNumber).Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.AccountNumberEmpty);
        }

        [Theory]
        [ClassData(typeof(NonPositiveIntData))]
        public async Task Should_throw_exception_given_non_positive_amount(int amount)
        {
            var request = WithdrawFundsRequest().WithAmount(amount).Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.AmountNotPositive);
        }

        [Fact]
        public async Task Should_throw_exception_given_non_existent_account_number()
        {
            var request = WithdrawFundsRequest().Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.AccountNumberNotExist);
        }

        [Fact]
        public async Task Should_throw_exception_given_insufficient_funds()
        {
            var accountNumber = "GB10BARC20040184197751";
            var balance = 140;
            var amount = 141;

            _bankAccountRepository.AlreadyContains(accountNumber, balance);

            var request = WithdrawFundsRequest()
                .WithAccountNumber(accountNumber)
                .WithAmount(amount)
                .Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.InsufficientFunds);
        }
    }
}