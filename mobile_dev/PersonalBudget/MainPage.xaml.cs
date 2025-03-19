namespace PersonalBudget
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void GoToRegistration(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(RegPage), true);
        }

        private void GoToMenuPage(object sender, EventArgs e)
        {
            string userName = UserNameEntry.Text;
            string userPassword = UserPasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(userName))
            {
                AppShell.Current.DisplayAlert("Error", "Поле имя пользователя не может быть пустым", "Ок");
                return;
            }

            if (string.IsNullOrWhiteSpace(userPassword))
            {
                AppShell.Current.DisplayAlert("Error", "Поле пароль не может быть пустым", "Ок");
                return;
            }

            bool isLoginSucceded = UserData.Users.Any(x => x.Password == userPassword && x.Name == userName);
            if (!isLoginSucceded)
            {
                AppShell.Current.DisplayAlert("Error", "Пользователь не существует", "Ок");
                return;
            }

            AppShell.Current.GoToAsync(nameof(MenuPage), true);
        }

    }
}