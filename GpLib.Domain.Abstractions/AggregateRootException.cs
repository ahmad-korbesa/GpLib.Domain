﻿using System;
using System.Runtime.Serialization;

namespace GpLib.Domain.Abstractions
{
    [Serializable]
    public class AggregateRootException : Exception
    {
        public AggregateRootException()
        {
        }

        public AggregateRootException(string message) : base(message)
        {
        }

        public AggregateRootException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AggregateRootException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
