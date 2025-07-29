using System;
using HidiffyProxy.Enum;

namespace HidiffyProxy.Model
{
    public class LogEntity
    {
        public LogLevel? Level { get; set; }
        public DateTime? Time { get; set; }
        public string Message { get; set; }
    }

    public abstract class LogFailure : Exception
    {
        protected LogFailure(string message = null) : base(message) { }
        public static LogFailure Unexpected(Exception error = null) => new LogUnexpectedFailure(error);
    }

    public class LogUnexpectedFailure : LogFailure
    {
        public Exception Error { get; }
        public LogUnexpectedFailure(Exception error = null) : base(error?.Message) { Error = error; }
    }
} 