using MVVMPattern.Views;

namespace MVVMPattern
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegistrationView), typeof(RegistrationView));
            Routing.RegisterRoute(nameof(MainView), typeof(MainView));
        }
    }
}
