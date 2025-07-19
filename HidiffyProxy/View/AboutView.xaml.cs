using HidiffyProxy.ViewModel;

namespace HidiffyProxy.View;

public partial class AboutView : ContentPage
{
	public AboutView()
	{
		InitializeComponent();
        BindingContext = new HidiffyProxy.ViewModel.AboutViewModel();

    }
}