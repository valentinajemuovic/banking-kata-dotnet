using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.Common.Guards
{
    public static class MoneyGuardExtensions
    {
        public static Money GuardAgainstNegative(this Money value, string message)
        {
            Guard.Against(value.IsNegative, message);
            return value;
        }

        public static Money GuardAgainstNonPositive(this Money value, string message)
        {
            Guard.Against(value.IsZeroOrNegative, message);
            return value;
        }
    }
}
