using MVVMPattern.ViewModels;
namespace MVVMPattern.Views;
public partial class RegistrationView : ContentPage
{
    public RegistrationView()
    {
        InitializeComponent();
        BindingContext = new RegistrationViewModel();
    }
}