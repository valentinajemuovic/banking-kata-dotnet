using FluentAssertions;
using Optivem.Kata.Banking.Core.Exceptions;
using Optivem.Kata.Banking.Core.UseCases.WithdrawFunds;
using Optivem.Kata.Banking.Test.Common.Data;
using System;
using System.Threading.Tasks;
using Xunit;

using static Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders.WithdrawFundsRequestBuilder;

namespace Optivem.Kata.Banking.Test.UseCases
{
    public class WithdrawFundsUseCaseTest
    {
        private readonly WithdrawFundsUseCase _useCase;

        public WithdrawFundsUseCaseTest()
        {
            _useCase = new WithdrawFundsUseCase();
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
    }
}
