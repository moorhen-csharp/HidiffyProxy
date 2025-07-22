namespace HidiffyProxy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                FlyoutBehavior = FlyoutBehavior.Locked;
            }
        }

    }
}
