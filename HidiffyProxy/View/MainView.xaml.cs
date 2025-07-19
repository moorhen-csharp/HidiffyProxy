using HidiffyProxy.ViewModel;

namespace HidiffyProxy.View
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new HidiffyProxy.ViewModel.MainViewModel();
        }
    }
}
