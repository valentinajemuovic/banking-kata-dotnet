using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.DataEnumerables
{
    internal class EmptyStringDataEnumerable : BaseDataEnumerable
    {
        private static readonly IEnumerable<object[]> Data = new List<object[]> 
        {
            GetEntry(null), 
            GetEntry(""), 
            GetEntry("   ") 
        };

        public EmptyStringDataEnumerable() : base(Data)
        {
        }

        private static object[] GetEntry(string? value)
        {
            return new object[] { value };
        }
    }
}
