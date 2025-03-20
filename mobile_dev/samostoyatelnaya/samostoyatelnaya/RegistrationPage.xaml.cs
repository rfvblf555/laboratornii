namespace samostoyatelnaya;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private void GoToMainPage(object sender, EventArgs e)
    {
        AppShell.Current.GoToAsync(nameof(MainPage), true);
    }

    private void OnTogglePasswordVisibility(object sender, TappedEventArgs e)
    {
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;


        if (PasswordEntry.IsPassword)
        {
            ToggleVisibilityImage.Source = "visible.png";
        }
        else
        {
            ToggleVisibilityImage.Source = "not_visible.svg";
        }
    }
}