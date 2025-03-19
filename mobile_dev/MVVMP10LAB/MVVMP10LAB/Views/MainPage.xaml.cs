using MVVMP10LAB.ViewsModels;
namespace MVVMP10LAB.Views;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}