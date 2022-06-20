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
            if (value == null || value.Equals(default(T)))
            {
                throw new ValidationException(message);
            }

            return value;
        }
    }
}
