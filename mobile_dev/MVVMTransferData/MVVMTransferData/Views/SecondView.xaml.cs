using MVVMTransferData.ViewModels;

namespace MVVMTransferData.Views;

public partial class SecondView : ContentPage
{
    public SecondView()
    {
        InitializeComponent();
        BindingContext = new SecondViewModel();
    }
}