using System;
using System.Runtime.Serialization;

namespace Fish.Mq
{
    [Serializable]
    public class GoFishException : Exception
    {
        public GoFishException(string message)
            : base(message)
        {
        }

        public GoFishException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GoFishException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}