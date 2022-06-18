using Optivem.Kata.Banking.Infrastructure.Fake.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure.Fake.Common
{
    internal class FakeGenerator<T>
    {
        private readonly Queue<T> _queue;

        public FakeGenerator()
        {
            _queue = new Queue<T>();
        }

        public T Next()
        {
            if (!_queue.Any())
            {
                throw new FakeException(FakeMessages.GeneratorDoesNotHaveNext);
            }

            return _queue.Dequeue();
        }

        public void Enqueue(T accountNumber)
        {
            _queue.Enqueue(accountNumber);
        }
    }
}
