using FluentAssertions;
using Optivem.Kata.Banking.Core.UseCases.ViewAccount;
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
        private readonly ViewAccountUseCase _useCase;

        public ViewAccountUseCaseTest()
        {
            _useCase = new ViewAccountUseCase();
        }

        [Fact]
        public async Task Nothing()
        {
            var request = new ViewAccountRequest();

            var response = await _useCase.HandleAsync(request);

            response.Should().NotBeNull();
        }
    }
}
