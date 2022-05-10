using System.Runtime.Serialization;

namespace Optivem.Kata.Banking.Core.Exceptions
{
    [Serializable]
    public class RepositoryException : Exception
    {
        protected RepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RepositoryException(string message) : base(message)
        {
        }
    }
}