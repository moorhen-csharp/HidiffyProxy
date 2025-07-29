using System;
using HidiffyProxy.Enum;

namespace HidiffyProxy.Model
{
    public class ProfileOptions
    {
        public TimeSpan UpdateInterval { get; set; }
    }

    public class SubscriptionInfo
    {
        public long Upload { get; set; }
        public long Download { get; set; }
        public long Total { get; set; }
        public DateTime Expire { get; set; }
        public string WebPageUrl { get; set; }
        public string SupportUrl { get; set; }

        public bool IsExpired => Expire <= DateTime.Now;
        public long Consumption => Upload + Download;
        public double Ratio => Total > 0 ? Math.Clamp((double)Consumption / Total, 0, 1) : 0;
        public TimeSpan Remaining => Expire - DateTime.Now;
    }

    public abstract class Profile
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
        public string TestUrl { get; set; }
        public ProfileType Type { get; protected set; }
    }

    public class RemoteProfile : Profile
    {
        public string Url { get; set; }
        public ProfileOptions Options { get; set; }
        public SubscriptionInfo SubInfo { get; set; }

        public RemoteProfile()
        {
            Type = ProfileType.Remote;
        }
    }

    public class LocalProfile : Profile
    {
        public LocalProfile()
        {
            Type = ProfileType.Local;
        }
    }
} 