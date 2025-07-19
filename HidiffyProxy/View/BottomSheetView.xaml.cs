namespace HidiffyProxy.View;

public partial class BottomSheetView : ContentView
{
	public BottomSheetView()
	{
		InitializeComponent();
	}
    private void OnCloseClicked(object sender, EventArgs e)
    {
        if (BindingContext is HidiffyProxy.ViewModel.MainViewModel vm)
            vm.IsModalVisible = false;
        this.IsVisible = false;
    }
}