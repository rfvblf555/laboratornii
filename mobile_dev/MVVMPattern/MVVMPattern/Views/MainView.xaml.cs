using MVVMPattern.ViewModels;
namespace MVVMPattern.Views;

public partial class MainView : ContentPage
{
    public MainView()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}