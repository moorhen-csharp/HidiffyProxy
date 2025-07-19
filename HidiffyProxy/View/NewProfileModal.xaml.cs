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
            await page.DisplayAlert("Info", "кнопка", "OK");
        else if (Application.Current?.MainPage != null)
            await Application.Current.MainPage.DisplayAlert("Info", "кнопка", "OK");
    }
}