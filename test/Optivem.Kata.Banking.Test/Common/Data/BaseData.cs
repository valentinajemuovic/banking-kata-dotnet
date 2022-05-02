using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Data
{
    internal class BaseData : IEnumerable<object[]>
    {
        private readonly IEnumerable<object[]> _data;

        public BaseData(IEnumerable<object[]> data)
        {
            _data = data;
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
