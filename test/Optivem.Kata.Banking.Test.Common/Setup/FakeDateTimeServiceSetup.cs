using Optivem.Kata.Banking.Infrastructure.Fake.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Setup
{
    public static class FakeDateTimeServiceSetup
    {
        public static void WillReturn(this FakeDateTimeService service, DateTime dateTime)
        {
            service.Enqueue(dateTime);
        }
    }
}
