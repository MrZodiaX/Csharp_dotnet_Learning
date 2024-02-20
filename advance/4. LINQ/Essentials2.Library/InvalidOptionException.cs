using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    [Serializable]
    public class InvalidOptionException : Exception
    {
        public InvalidOptionException():base()
        {}
        public InvalidOptionException(string message): base(message)
        {}

        public InvalidOptionException(string message, Exception innerException) : base(message, innerException)
        {}

        protected InvalidOptionException(SerializationInfo info, StreamingContext ctx) : base(info, ctx)
        {}
    }
}
