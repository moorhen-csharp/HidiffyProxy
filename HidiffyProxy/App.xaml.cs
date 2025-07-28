namespace HidiffyProxy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override void OnStart()
        {
            base.OnStart();
            // Проверяем, был ли уже пройден интро-экран
            if (Preferences.Default.Get("IntroCompleted", false))
            {
                Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                Shell.Current.GoToAsync("//IntroView");
            }
        }
    }
}