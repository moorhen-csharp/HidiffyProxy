using System;
using HidiffyProxy.Enum;

namespace HidiffyProxy.Model
{
    public static class Constants
    {
        public const string AppName = "Hiddify";
        public const string GithubUrl = "https://github.com/hiddify/hiddify-next";
        public const string GithubReleasesApiUrl = "https://api.github.com/repos/hiddify/hiddify-next/releases";
        public const string GithubLatestReleaseUrl = "https://github.com/hiddify/hiddify-next/releases/latest";
        public const string AppCastUrl = "https://raw.githubusercontent.com/hiddify/hiddify-next/main/appcast.xml";
        public const string TelegramChannelUrl = "https://t.me/hiddify";
        public const string PrivacyPolicyUrl = "https://hiddify.com/privacy-policy/";
        public const string TermsAndConditionsUrl = "https://hiddify.com/terms/";
        public const string CfWarpPrivacyPolicy = "https://www.cloudflare.com/application/privacypolicy/";
        public const string CfWarpTermsOfService = "https://www.cloudflare.com/application/terms/";
    }

    public class AppInfoEntity
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string BuildNumber { get; set; }
        public ReleaseType Release { get; set; }
        public string OperatingSystem { get; set; }
        public string OperatingSystemVersion { get; set; }
        public EnvironmentType Environment { get; set; }

        public string UserAgent => $"HiddifyNext/{Version} ({OperatingSystem}) like ClashMeta v2ray sing-box";
        public string PresentVersion => Environment == EnvironmentType.Prod ? Version : $"{Version} {Environment}";
        public string Format() => $"{Name} v{Version} ({BuildNumber}) [{Environment}]\n{Release} release\n{OperatingSystem} [{OperatingSystemVersion}]";
    }

    public class OptionalRange
    {
        public int? Min { get; set; }
        public int? Max { get; set; }

        public string Format() => (Min.HasValue && Max.HasValue) ? $"{Min}-{Max}" : Min?.ToString() ?? Max?.ToString() ?? string.Empty;
        public static OptionalRange Parse(string input)
        {
            var parts = input.Split('-');
            if (parts.Length == 1 && string.IsNullOrEmpty(parts[0])) return new OptionalRange();
            if (parts.Length == 1) return new OptionalRange { Min = int.Parse(parts[0]) };
            if (parts.Length == 2) return new OptionalRange { Min = int.Parse(parts[0]), Max = int.Parse(parts[1]) };
            throw new Exception($"Invalid range: {input}");
        }
    }

    // Базовый тип ошибки (Failure)
    public abstract class Failure : Exception
    {
        protected Failure(string message = null) : base(message) { }
    }
} 