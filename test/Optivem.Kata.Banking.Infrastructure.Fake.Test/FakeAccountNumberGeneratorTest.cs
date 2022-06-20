using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.Exceptions;
using Optivem.Kata.Banking.Infrastructure.Fake.Generators;
using Optivem.Kata.Banking.Test.Common.Givens;
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

            _generator.WillGenerate(expectedValue);

            ShouldGenerateNext(expectedValue);
            ShouldThrowExceptionOnNext();
        }

        [Fact]
        public void Should_return_next_elements_when_there_are_multiple_elements()
        {
            var expectedValue1 = "GB54BARC20032611545669";
            var expectedValue2 = "GB36BARC20038032622823";
            var expectedValue3 = "GB10BARC20040184197751";

            _generator.WillGenerate(expectedValue1);
            _generator.WillGenerate(expectedValue2);
            _generator.WillGenerate(expectedValue3);

            ShouldGenerateNext(expectedValue1);
            ShouldGenerateNext(expectedValue2);
            ShouldGenerateNext(expectedValue3);

            ShouldThrowExceptionOnNext();
        }

        private void ShouldGenerateNext(string accountNumber)
        {
            var next = _generator.Next();
            next.Should().BeEquivalentTo(AccountNumber.From(accountNumber));
        }

        private void ShouldThrowExceptionOnNext()
        {
            var action = () => _generator.Next();

            action.Should().Throw<FakeException>()
                .WithMessage(FakeMessages.GeneratorDoesNotHaveNext);
        }
    }
}