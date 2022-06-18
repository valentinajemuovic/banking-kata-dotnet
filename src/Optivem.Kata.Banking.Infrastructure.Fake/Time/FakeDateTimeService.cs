using Optivem.Kata.Banking.Core.Domain.Time;
using Optivem.Kata.Banking.Infrastructure.Fake.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure.Fake.Time
{
    public class FakeDateTimeService : IDateTimeService
    {
        private readonly FakeGenerator<DateTime> _generator;

        public FakeDateTimeService()
        {
            _generator = new FakeGenerator<DateTime>();
        }

        public DateTime Now()
        {
            return _generator.Next();
        }

        public void Enqueue(DateTime dateTime)
        {
            _generator.Enqueue(dateTime);
        }
    }
}
