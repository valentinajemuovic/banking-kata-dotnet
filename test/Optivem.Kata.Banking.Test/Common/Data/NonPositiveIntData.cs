using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Data
{
    internal class NonPositiveIntData : BaseData
    {
        private static readonly IEnumerable<object[]> Data = new List<object[]>
        {
            GetEntry(0),
            GetEntry(-1),
            GetEntry(-10),
        };

        public NonPositiveIntData() : base(Data)
        {
        }

        private static object[] GetEntry(int value)
        {
            return new object[] { value };
        }
    }
}
