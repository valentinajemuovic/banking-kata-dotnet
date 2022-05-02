using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.DataEnumerables
{
    internal class NegativeIntDataEnumerable : BaseDataEnumerable
    {
        private static readonly IEnumerable<object[]> Data = new List<object[]>
        {
            GetEntry(-1),
            GetEntry(-10),
        };

        public NegativeIntDataEnumerable() : base(Data)
        {
        }

        private static object[] GetEntry(int value)
        {
            return new object[] { value };
        }
    }
}
