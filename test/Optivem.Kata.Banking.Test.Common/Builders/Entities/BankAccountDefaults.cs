using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Builders.Entities
{
    public class BankAccountDefaults
    {
        public const long DefaultAccountId = 322352352342;
        public const string DefaultAccountNumber = "GB10BARC20040184197751";
        public const string DefaultFirstName = "John";
        public const string DefaultLastName = "Smith";
        public static DateOnly DefaultOpeningDate = new DateOnly(2022, 10, 25);
        public const int DefaultBalance = 100;
    }
}
