namespace PersonalBudget;

public partial class RegPage : ContentPage
{
    public RegPage()
    {
        InitializeComponent();
    }

    private void RegisterUser(object sender, EventArgs e)
    {
        string userEmail = UserEmailEntry.Text;
        string userName = UserNameEntry.Text;
        string userPassword = UserPasswordEntry.Text;

        bool isEmailEmpty = string.IsNullOrWhiteSpace(userName);
        if (isEmailEmpty)
        {
            AppShell.Current.DisplayAlert("Error", "���� ��� ������������ �� ����� ���� ������", "��");
            return;
        }

        bool isNameEmpty = string.IsNullOrWhiteSpace(userName);
        if (isNameEmpty)
        {
            AppShell.Current.DisplayAlert("Error", "���� ��� ������������ �� ����� ���� ������", "��");
            return;
        }

        bool isPasswordEmpty = string.IsNullOrWhiteSpace(userPassword);
        if (isPasswordEmpty)
        {
            AppShell.Current.DisplayAlert("Error", "���� ������ �� ����� ���� ������", "��");
            return;
        }

        bool isNameExistAlready = UserData.Users.Any(x => x.Name == userName);
        if (isNameExistAlready)
        {
            AppShell.Current.DisplayAlert("Error", "������������ � ����� ������ ��� ���������������", "��");
            return;
        }

        bool isEmailExistAlready = UserData.Users.Any(x => x.Email == userEmail);
        if (isEmailExistAlready)
        {
            AppShell.Current.DisplayAlert("Error", "������������ � ����� ������ ��� ���������������", "��");
            return;
        }


        UserData.Users.Add(new User(userName, userPassword, userEmail));

        AppShell.Current.GoToAsync("..", true);
    }
}