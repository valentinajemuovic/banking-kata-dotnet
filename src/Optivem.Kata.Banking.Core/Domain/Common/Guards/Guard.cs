using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.Common.Guards
{
    public static class Guard
    {
        public static void Against(this Func<bool> func, string message)
        {
            if (func())
            {
                throw new ValidationException(message);
            }
        }
    }
}
