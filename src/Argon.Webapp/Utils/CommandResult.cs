using System;
using System.Runtime.Serialization;

namespace Argon.Webapp.Utils
{
    public struct CommandResult : ISerializable
    {
        public bool IsFailure { get; }
        public bool IsSuccess { get; }
        public string Error { get; }
        
        private CommandResult(bool isFailure, string error)
        {
            IsFailure = isFailure;
            IsSuccess = !isFailure;
            Error = error;
        }

        public static CommandResult Fail(string error)
        {
            return new CommandResult(true, error);
        }

        public static CommandResult Ok()
        {
            return new CommandResult(false, string.Empty);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
