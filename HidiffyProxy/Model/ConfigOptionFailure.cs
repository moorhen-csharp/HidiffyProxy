using System;

namespace HidiffyProxy.Model
{
    public abstract class ConfigOptionFailure : Exception
    {
        protected ConfigOptionFailure(string message = null) : base(message) { }
        public static ConfigOptionFailure Unexpected(Exception error = null) => new ConfigOptionUnexpectedFailure(error);
        public static ConfigOptionFailure MissingWarp() => new MissingWarpConfigFailure();
    }

    public class ConfigOptionUnexpectedFailure : ConfigOptionFailure
    {
        public Exception Error { get; }
        public ConfigOptionUnexpectedFailure(Exception error = null) : base(error?.Message) { Error = error; }
    }

    public class MissingWarpConfigFailure : ConfigOptionFailure
    {
        public MissingWarpConfigFailure() : base("Missing WARP config") { }
    }
} 