using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using Optivem.Kata.Banking.Core.UseCases.WithdrawFunds;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Data;
using Optivem.Kata.Banking.Test.Common.Setup;
using System;
using System.Threading.Tasks;
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
        [ClassData(typeof(NullEmptyWhitespaceStringData))]
        public async Task Should_throw_exception_given_empty_account_number(string accountNumber)
        {
            var request = WithdrawFundsRequest().AccountNumber(accountNumber).Build();

            Func<Task> action = () => _useCase.HandleAsync(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.AccountNumberEmpty);
        }

        [Theory]
        [ClassData(typeof(NonPositiveIntData))]
        public async Task Should_throw_exception_given_non_positive_amount(int amount)
        {
            var request = WithdrawFundsRequest().Amount(amount).Build();

            Func<Task> action = () => _useCase.HandleAsync(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.AmountNotPositive);
        }

        [Fact]
        public async Task Should_throw_exception_given_non_existent_account_number()
        {
            var request = WithdrawFundsRequest().Build();

            Func<Task> action = () => _useCase.HandleAsync(request);

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
                .AccountNumber(accountNumber)
                .Amount(amount)
                .Build();

            Func<Task> action = () => _useCase.HandleAsync(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.InsufficientFunds);
        }
    }
}
