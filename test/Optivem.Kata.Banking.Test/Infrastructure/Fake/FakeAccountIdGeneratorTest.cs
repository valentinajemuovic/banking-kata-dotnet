using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.Exceptions;
using Optivem.Kata.Banking.Test.Common.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Infrastructure.Fake
{
    public class FakeAccountIdGeneratorTest
    {
        private readonly FakeAccountIdGenerator _generator;

        public FakeAccountIdGeneratorTest()
        {
            _generator = new FakeAccountIdGenerator();
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
            var expectedValue = 2323523523;

            _generator.WillGenerate(expectedValue);

            ShouldGenerateNext(expectedValue);
            ShouldThrowExceptionOnNext();
        }

        [Fact]
        public void Should_return_next_elements_when_there_are_multiple_elements()
        {
            var expectedValue1 = 3523523;
            var expectedValue2 = 3462234234;
            var expectedValue3 = 524523523523;

            _generator.WillGenerate(expectedValue1);
            _generator.WillGenerate(expectedValue2);
            _generator.WillGenerate(expectedValue3);

            ShouldGenerateNext(expectedValue1);
            ShouldGenerateNext(expectedValue2);
            ShouldGenerateNext(expectedValue3);

            ShouldThrowExceptionOnNext();
        }

        private void ShouldGenerateNext(long accountId)
        {
            var next = _generator.Next();
            next.Should().BeEquivalentTo(AccountId.From(accountId));
        }

        private void ShouldThrowExceptionOnNext()
        {
            var action = () => _generator.Next();

            action.Should().Throw<FakeException>()
                .WithMessage(FakeMessages.GeneratorDoesNotHaveNext);
        }
    }
}
