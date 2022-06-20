using System.Collections.Generic;

namespace Optivem.Kata.Banking.Test.Common.Data
{
    public class NullEmptyWhitespaceStringData : BaseData
    {
        private static readonly IEnumerable<object[]> Data = new List<object[]>
        {
            GetEntry(null),
            GetEntry(""),
            GetEntry("   ")
        };

        public NullEmptyWhitespaceStringData() : base(Data)
        {
        }

        private static object[] GetEntry(string? value)
        {
            return new object[] {value};
        }
    }
}