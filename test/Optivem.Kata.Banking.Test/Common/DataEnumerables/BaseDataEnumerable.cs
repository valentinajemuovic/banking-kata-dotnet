using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.DataEnumerables
{
    internal class BaseDataEnumerable : IEnumerable<object[]>
    {
        private IEnumerable<object[]> _data;

        public BaseDataEnumerable(IEnumerable<object[]> data)
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
