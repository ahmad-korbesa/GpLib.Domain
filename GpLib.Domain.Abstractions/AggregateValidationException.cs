using System;
using System.Runtime.Serialization;

namespace GpLib.Domain.Abstractions
{
    [Serializable]
    public class AggregateValidationException : Exception
    {
        public AggregateValidationException()
        {
        }

        public AggregateValidationException(string message) : base(message)
        {
        }

        public AggregateValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AggregateValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}