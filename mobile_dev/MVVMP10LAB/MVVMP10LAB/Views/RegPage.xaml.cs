using MVVMP10LAB.ViewsModels;
namespace MVVMP10LAB.Views;
public partial class RegPage : ContentPage
{
    public RegPage()
    {
        InitializeComponent();
        BindingContext = new RegViewModel();
    }
}