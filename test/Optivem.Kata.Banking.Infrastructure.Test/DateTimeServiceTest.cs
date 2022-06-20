using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.Time;
using Optivem.Kata.Banking.Infrastructure;
using Optivem.Kata.Banking.Infrastructure.Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Infrastructure
{
    public class DateTimeServiceTest : BaseTest
    {
        private readonly IDateTimeService _dateTimeService;

        public DateTimeServiceTest(HostFixture fixture) : base(fixture)
        {
            _dateTimeService = GetService<IDateTimeService>();
        }

        [Fact]
        public void Should_return_current_date_time()
        {
            var now = _dateTimeService.Now();
            now.Should().BeAfter(DateTime.MinValue);
        }
    }
}
