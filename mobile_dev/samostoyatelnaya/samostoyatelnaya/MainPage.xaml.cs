namespace samostoyatelnaya
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void GoToRegistrationPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(RegistrationPage), true);
        }

        private void OnTogglePasswordVisibility(object sender, EventArgs e)
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
}
