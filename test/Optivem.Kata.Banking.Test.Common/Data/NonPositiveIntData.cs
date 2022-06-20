using System.Collections.Generic;

namespace Optivem.Kata.Banking.Test.Common.Data
{
    public class NonPositiveIntData : BaseData
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
            return new object[] {value};
        }
    }
}