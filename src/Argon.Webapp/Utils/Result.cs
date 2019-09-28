using System;
using System.Runtime.Serialization;

namespace Argon.Webapp.Utils
{
    public struct Result : ISerializable
    {
        public bool IsFailure { get; }
        public bool IsSuccess { get; }
        public string Error { get; }
        
        private Result(bool isFailure, string error)
        {
            IsFailure = isFailure;
            IsSuccess = !isFailure;
            Error = error;
        }

        public static Result Fail(string error)
        {
            return new Result(true, error);
        }

        public static Result Ok()
        {
            return new Result(false, string.Empty);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
