using Microsoft.Maui.Controls;
using HidiffyProxy.ViewModel;

namespace HidiffyProxy.View
{
    public partial class IntroView : ContentPage
    {
        public IntroView()
        {
            InitializeComponent();
            BindingContext = new IntroViewModel(OnIntroCompleted);
        }

        private async void OnIntroCompleted()
        {
            // Сохраняем флаг завершения интро
            Preferences.Default.Set("IntroCompleted", true);
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
} 