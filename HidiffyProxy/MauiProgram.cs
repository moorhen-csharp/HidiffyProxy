using HidiffyProxy.Service;
using HidiffyProxy.View;
using HidiffyProxy.ViewModel;
using Microsoft.Extensions.Logging;

namespace HidiffyProxy
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var exception = (Exception)args.ExceptionObject;
                System.Diagnostics.Debug.WriteLine("Unhandled Exception: " + exception);
            };

            // --- ViewModels ---
            builder.Services.AddSingleton<ConfigViewModel>();
            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddSingleton<AboutViewModel>();
            builder.Services.AddSingleton<JournalViewModel>();
            builder.Services.AddSingleton<MainViewModel>();

            // --- Views ---
            builder.Services.AddTransient<ConfigView>();
            builder.Services.AddTransient<SettingsView>();
            builder.Services.AddTransient<AboutView>();
            builder.Services.AddTransient<JournalView>();
            builder.Services.AddTransient<MainView>();

            // --- Services ---
            builder.Services.AddSingleton<ThemeService>();

            return builder.Build();
        }
    }
}
