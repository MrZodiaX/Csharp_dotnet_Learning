using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    [Serializable]
	internal class invalidOptionException : Exception
	{
        public invalidOptionException() : base() {}

        public invalidOptionException(string mssg) : base(mssg) {}

        public invalidOptionException(string msg, Exception innerEx) : base(msg, innerEx) {}

        protected  invalidOptionException(SerializationInfo info, StreamingContext ctx) : base(info, ctx) {}
    }
}
