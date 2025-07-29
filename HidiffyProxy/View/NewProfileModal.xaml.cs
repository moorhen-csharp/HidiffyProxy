namespace HidiffyProxy.View;

public partial class NewProfileModal : ContentView
{
	public NewProfileModal()
	{
		InitializeComponent();
	}
    private void OnCloseClicked(object sender, EventArgs e)
    {
        if (BindingContext is HidiffyProxy.ViewModel.MainViewModel vm)
            vm.IsModalVisible = false;
        this.IsVisible = false;
    }

    private async void OnScanQrTapped(object sender, EventArgs e)
    {
        if (this.Parent is Page page)
            await page.DisplayAlert("Info", "������", "OK");
        else if (Application.Current?.MainPage != null)
            await Application.Current.MainPage.DisplayAlert("Info", "������", "OK");
    }

    private void OnAddProfileClicked(object sender, EventArgs e)
    {
        if (BindingContext is HidiffyProxy.ViewModel.MainViewModel vm && ProfileNameEntry != null)
        {
            var name = ProfileNameEntry.Text?.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                vm.AddProfileCommand.Execute(name);
                ProfileNameEntry.Text = string.Empty;
                vm.IsModalVisible = false;
                this.IsVisible = false;
            }
        }
    }
}