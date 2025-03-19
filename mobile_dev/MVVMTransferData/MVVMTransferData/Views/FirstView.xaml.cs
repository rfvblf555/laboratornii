using MVVMTransferData.ViewModels;

namespace MVVMTransferData.Views;
public partial class FirstView : ContentPage
{
    public FirstView()
    {
        InitializeComponent();
        BindingContext = new FirstViewModel();
    }

    private void GoToSecondPage(object sender, EventArgs e)
    {
        AppShell.Current.GoToAsync(nameof(SecondView), true);
    }
}