using System;
using System.Runtime.Serialization;

namespace TvApiLabUr.Common
{
    [Serializable]
    public class TvApiException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public TvApiException()
        {
        }

        public TvApiException(string message) : base(message)
        {
        }

        public TvApiException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TvApiException(SerializationInfo info,StreamingContext context) : base(info, context)
        {
        }
    }
}