namespace HidiffyProxy.View;

public partial class JournalView : ContentPage
{
	public JournalView()
	{
		InitializeComponent();
        BindingContext = new HidiffyProxy.ViewModel.JournalViewModel();

    }
}