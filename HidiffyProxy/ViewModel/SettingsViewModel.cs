using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HidiffyProxy.Base;
using HidiffyProxy.Service;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HidiffyProxy.ViewModel
{


    public partial class SettingsViewModel : ObservableObject
    {
        private readonly ThemeService themeService;
        // private readonly IDialogService dialogService;
        #region ObservableCollection
        public ObservableCollection<string> ThemeOptions { get; } = new() { "Системная", "Светлая", "Тёмная" };
        public ObservableCollection<string> LanguageOptions { get; } = new() { "Русский(ru)", "English(en)", "Deutsch (de)", "Русский дореформенный (ruru_old)" };
        #endregion

        #region ObservableProperty
        [ObservableProperty]
        private string selectedTheme;
        [ObservableProperty]
        private string selectedLanguage;
        [ObservableProperty]
        private bool autoIpCheck = true;
        [ObservableProperty]
        private bool dynamicNotification = false;
        [ObservableProperty]
        private bool hapticFeedback = true;
        [ObservableProperty]
        private bool ignoreBatteryOptimization = false;
        [ObservableProperty]
        private bool debugMode = false;
        [ObservableProperty]
        private bool developerTestingMode;
        #endregion

        //public SettingsViewModel(ThemeService themeService)
        //{
        //    this.themeService = themeService;
        //    //this.dialogService = dialogService;
        //    // Определяем текущую тему устройства
        //    var currentTheme = themeService.GetCurrentTheme();
        //    selectedTheme = ThemeOptions[(int)currentTheme];
        //    developerTestingMode = false;
        //}

        public SettingsViewModel(ThemeService themeService)
        {
            this.themeService = themeService;
            //this.dialogService = dialogService;
            //Определяем текущую тему устройства
            var currentTheme = themeService.GetCurrentTheme();
            selectedTheme = ThemeOptions[(int)currentTheme];
            developerTestingMode = false;
        }
        #region RelayCommand
        [RelayCommand]
        private void ChangeTheme(string theme)
        {
            SelectedTheme = theme;
            switch (theme)
            {
                case "Светлая":
                    themeService.SetTheme(AppThemeMode.Light);
                    break;
                case "Тёмная":
                    themeService.SetTheme(AppThemeMode.Dark);
                    break;
                default:
                    themeService.SetTheme(AppThemeMode.System);
                    break;
            }
        }
        #endregion

        #region Methods
        partial void OnSelectedThemeChanged(string value)
        {
            switch (value)
            {
                case "Светлая":
                    themeService.SetTheme(AppThemeMode.Light);
                    break;
                case "Тёмная":
                    themeService.SetTheme(AppThemeMode.Dark);
                    break;
                default:
                    themeService.SetTheme(AppThemeMode.System);
                    // Принудительно обновляем SelectedTheme, чтобы всегда соответствовать системной теме
                    selectedTheme = ThemeOptions[(int)themeService.GetCurrentTheme()];
                    break;
            }
        }
        #endregion

    }
}
