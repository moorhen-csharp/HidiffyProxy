using HidiffyProxy.ViewModel;

namespace HidiffyProxy.View;

public partial class SettingsView : ContentPage
{
    public SettingsView(SettingsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}