using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.DataEnumerables
{
    public class EmptyStringDataEnumerable : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var records = new List<object[]> { GetData(null), GetData(""), GetData("   ") };
            return records.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static object[] GetData(string? value)
        {
            return new object[] { value };
        }
    }
}
