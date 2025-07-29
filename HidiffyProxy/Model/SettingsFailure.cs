using System;

namespace HidiffyProxy.Model
{
    public abstract class SettingsFailure : Exception
    {
        protected SettingsFailure(string message = null) : base(message) { }
        public static SettingsFailure Unexpected(Exception error = null) => new SettingsUnexpectedFailure(error);
    }

    public class SettingsUnexpectedFailure : SettingsFailure
    {
        public Exception Error { get; }
        public SettingsUnexpectedFailure(Exception error = null) : base(error?.Message) { Error = error; }
    }
} 