using System.Runtime.Serialization;

namespace Optivem.Kata.Banking.Core.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ValidationException(string message) : base(message)
        {
        }
    }
}