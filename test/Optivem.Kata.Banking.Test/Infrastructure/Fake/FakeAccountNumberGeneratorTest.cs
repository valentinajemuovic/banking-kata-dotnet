using FluentAssertions;
using Optivem.Kata.Banking.Infrastructure.Fake.Exceptions;
using Optivem.Kata.Banking.Infrastructure.Fake.Generators;
using Optivem.Kata.Banking.Test.Common.Assert;
using Optivem.Kata.Banking.Test.Common.Givens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Infrastructure.Fake
{
    public class FakeAccountNumberGeneratorTest
    {
        private readonly FakeAccountNumberGenerator _generator;

        public FakeAccountNumberGeneratorTest()
        {
            _generator = new FakeAccountNumberGenerator();
        }

        [Fact]
        public void Should_throw_exception_when_no_elements()
        {
            var action = () => _generator.Next();

            action.Should().ThrowExactly<FakeException>()
                .WithMessage(FakeMessages.GeneratorDoesNotHaveNext);
        }

        [Fact]
        public void Should_return_next_element_when_there_is_one_element()
        {
            var expectedValue = "GB54BARC20032611545669";

            _generator.SetupNext(expectedValue);

            _generator.ShouldGenerateNext(expectedValue);
            _generator.ShouldThrowExceptionOnNext();
        }
    }
}
