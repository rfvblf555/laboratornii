using MVVMTransferData.Views;

namespace MVVMTransferData
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FirstView), typeof(FirstView));
            Routing.RegisterRoute(nameof(SecondView), typeof(SecondView));
        }
    }
}
