using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.Common.Guards
{
    public static class ObjectGuardExtensions
    {
        public static T GuardAgainstEmpty<T>(this T value, string message)
        {
            Guard.Against(() => IsEmpty(value), message);
            return value;
        }

        private static bool IsEmpty<T>(T value)
        {
            return value == null || value.Equals(default(T));
        }
    }
}
