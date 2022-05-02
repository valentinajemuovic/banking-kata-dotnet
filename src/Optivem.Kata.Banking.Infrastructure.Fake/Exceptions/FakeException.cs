using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure.Fake.Exceptions
{
    public class FakeException : Exception
    {
        public FakeException(string? message) : base(message)
        {
        }
    }
}
