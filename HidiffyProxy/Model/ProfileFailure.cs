using System;

namespace HidiffyProxy.Model
{
    public abstract class ProfileFailure : Exception
    {
        protected ProfileFailure(string message = null) : base(message) { }

        public static ProfileFailure Unexpected(Exception error = null) => new ProfileUnexpectedFailure(error);
        public static ProfileFailure NotFound() => new ProfileNotFoundFailure();
        public static ProfileFailure InvalidUrl() => new ProfileInvalidUrlFailure();
        public static ProfileFailure InvalidConfig(string message = null) => new ProfileInvalidConfigFailure(message);
    }

    public class ProfileUnexpectedFailure : ProfileFailure
    {
        public Exception Error { get; }
        public ProfileUnexpectedFailure(Exception error = null) : base(error?.Message) { Error = error; }
    }

    public class ProfileNotFoundFailure : ProfileFailure
    {
        public ProfileNotFoundFailure() : base("Profile not found") { }
    }

    public class ProfileInvalidUrlFailure : ProfileFailure
    {
        public ProfileInvalidUrlFailure() : base("Invalid profile URL") { }
    }

    public class ProfileInvalidConfigFailure : ProfileFailure
    {
        public ProfileInvalidConfigFailure(string message = null) : base(message ?? "Invalid profile config") { }
    }
} 