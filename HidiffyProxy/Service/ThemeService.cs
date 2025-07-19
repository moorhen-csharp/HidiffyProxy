namespace HidiffyProxy.Service
{
    public enum AppThemeMode
    {
        Light,
        Dark,
        System
    }

    public class ThemeService
    {
        public ThemeService()
        {
            // Подписываемся на изменение темы
            Application.Current.RequestedThemeChanged += OnRequestedThemeChanged;
        }

        public void SetTheme(AppThemeMode mode)
        {
            switch (mode)
            {
                case AppThemeMode.Light:
                    App.Current.UserAppTheme = AppTheme.Light;
                    break;
                case AppThemeMode.Dark:
                    App.Current.UserAppTheme = AppTheme.Dark;
                    break;
                case AppThemeMode.System:
                default:
                    App.Current.UserAppTheme = AppTheme.Unspecified;
                    break;
            }

            UpdateColors(App.Current.UserAppTheme);
        }

        public AppThemeMode GetCurrentTheme()
        {
            return App.Current.UserAppTheme switch
            {
                AppTheme.Light => AppThemeMode.Light,
                AppTheme.Dark => AppThemeMode.Dark,
                _ => AppThemeMode.System
            };
        }

        private void OnRequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            UpdateColors(e.RequestedTheme);
        }

        private void UpdateColors(AppTheme theme)
        {
            if (theme == AppTheme.Light)
            {
                // Светлая тема — чёрный текст
                App.Current.Resources["TextColor"] = Colors.Black;
                App.Current.Resources["TextModalColor"] = Color.Parse("#465b94");
                App.Current.Resources["BackgroundColor"] = Colors.White;
                App.Current.Resources["ButtonBackgroundColor"] = Color.Parse("#e6e6ef");
                App.Current.Resources["ModalBackgroundColor"] = Color.Parse("#fcfafd");
            }
            else
            {
                // Тёмная тема — белый текст
                App.Current.Resources["TextColor"] = Colors.White;
                App.Current.Resources["TextModalColor"] = Color.Parse("#b2c4ef");
                App.Current.Resources["BackgroundColor"] = Color.Parse("#121212");
                App.Current.Resources["ButtonBackgroundColor"] = Color.Parse("#2d2f3c");
                App.Current.Resources["ModalBackgroundColor"] = Color.Parse("#23202A");
            }
        }
    }
}
