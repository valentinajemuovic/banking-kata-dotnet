using FluentAssertions;
using Optivem.Kata.Banking.Core.Exceptions;
using Optivem.Kata.Banking.Core.UseCases.OpenAccount;
using Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using static Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders.OpenAccountRequestBuilder;

namespace Optivem.Kata.Banking.Test.UseCases
{
    public class OpenAccountUseCaseTest
    {
        private OpenAccountUseCase _useCase;

        public OpenAccountUseCaseTest()
        {
            _useCase = new OpenAccountUseCase();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task Should_throw_exception_given_empty_first_name(string firstName)
        {
            var request = AnOpenAccount().FirstName(firstName).Build();

            Func<Task> action = () => _useCase.HandleAsync(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.FirstNameEmpty);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task Should_throw_exception_given_empty_last_name(string lastName)
        {
            var request = AnOpenAccount().LastName(lastName).Build();

            Func<Task> action = () => _useCase.HandleAsync(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.LastNameEmpty);
        }
    }
}
