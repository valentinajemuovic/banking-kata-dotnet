using FluentAssertions;
using Optivem.Kata.Banking.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Infrastructure
{
    public class DateTimeServiceTest
    {
        private readonly DateTimeService _dateTimeService;

        public DateTimeServiceTest()
        {
            _dateTimeService = new DateTimeService();
        }

        [Fact]
        public void Should_return_current_date_time()
        {
            var now = _dateTimeService.Now();
            now.Should().BeAfter(DateTime.MinValue);
        }
    }
}
