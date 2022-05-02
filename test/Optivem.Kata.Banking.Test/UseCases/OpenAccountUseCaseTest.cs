using FluentAssertions;
using Optivem.Kata.Banking.Core.Exceptions;
using Optivem.Kata.Banking.Core.UseCases.OpenAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
            var request = new OpenAccountRequest();
            request.FirstName = firstName;

            Func<Task> action = () => _useCase.HandleAsync(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.FirstNameEmpty);
        }
    }
}
