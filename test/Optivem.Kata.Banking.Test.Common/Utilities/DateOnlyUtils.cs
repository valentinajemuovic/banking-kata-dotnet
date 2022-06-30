using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Utilities
{
    public static class DateOnlyUtils
    {
        public static DateOnly From(string dateOnlyString)
        {
            return DateOnly.Parse(dateOnlyString);
        }
    }
}
