using FluentAssertions;
using Optivem.Kata.Banking.Infrastructure.Fake.Exceptions;
using Optivem.Kata.Banking.Infrastructure.Fake.Time;
using Optivem.Kata.Banking.Test.Common.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Infrastructure.Fake
{
    public class FakeDateTimeServiceTest
    {
        private readonly FakeDateTimeService _service;

        public FakeDateTimeServiceTest()
        {
            _service = new FakeDateTimeService();
        }

        [Fact]
        public void Should_return_current_time()
        {
            var expectedValue = new DateTime(2022, 10, 25, 5, 59, 27);

            _service.WillReturn(expectedValue);

            ShouldGenerateNext(expectedValue);
            ShouldThrowExceptionOnNext();
        }

        private void ShouldGenerateNext(DateTime dateTime)
        {
            var now = _service.Now();
            now.Should().Be(dateTime);
        }

        private void ShouldThrowExceptionOnNext()
        {
            var action = () => _service.Now();

            action.Should().Throw<FakeException>()
                .WithMessage(FakeMessages.GeneratorDoesNotHaveNext);
        }
    }
}
