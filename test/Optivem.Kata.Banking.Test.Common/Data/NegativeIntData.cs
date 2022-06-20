using System.Collections.Generic;

namespace Optivem.Kata.Banking.Test.Common.Data
{
    public class NegativeIntData : BaseData
    {
        private static readonly IEnumerable<object[]> Data = new List<object[]>
        {
            GetEntry(-1),
            GetEntry(-10),
        };

        public NegativeIntData() : base(Data)
        {
        }

        private static object[] GetEntry(int value)
        {
            return new object[] {value};
        }
    }
}