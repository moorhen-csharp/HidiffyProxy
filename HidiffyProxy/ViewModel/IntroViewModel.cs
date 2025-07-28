using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HidiffyProxy.ViewModel
{
    public class IntroViewModel : BindableObject
    {
        public ObservableCollection<string> LanguageOptions { get; } = new ObservableCollection<string> { "Русский", "English" };
        public ObservableCollection<string> RegionOptions { get; } = new ObservableCollection<string> { "Россия (ru)", "Global" };

        private string _selectedLanguage;
        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set { _selectedLanguage = value; OnPropertyChanged(); }
        }

        private string _selectedRegion;
        public string SelectedRegion
        {
            get => _selectedRegion;
            set { _selectedRegion = value; OnPropertyChanged(); }
        }

        private bool _analyticsEnabled = true;
        public bool AnalyticsEnabled
        {
            get => _analyticsEnabled;
            set { _analyticsEnabled = value; OnPropertyChanged(); }
        }

        public ICommand ContinueCommand { get; }
        public ICommand PrivacyPolicyTap { get; }

        private readonly Action _onIntroCompleted;
        public IntroViewModel(Action onIntroCompleted)
        {
            _onIntroCompleted = onIntroCompleted;
            ContinueCommand = new Command(OnContinue);
            PrivacyPolicyTap = new Command(OnPrivacyPolicy);
        }

        private void OnContinue()
        {
            // TODO: Сохранить настройки
            _onIntroCompleted?.Invoke();
        }

        private async void OnPrivacyPolicy()
        {
            var url = "https://example.com/privacy";
            try
            {
                await Browser.Default.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
            }
            catch { }
        }
    }
} 