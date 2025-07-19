namespace HidiffyProxy.View;

public partial class ConfigView : ContentPage
{
	public ConfigView()
	{
		InitializeComponent();
        BindingContext = new HidiffyProxy.ViewModel.ConfigViewModel();
    }
}