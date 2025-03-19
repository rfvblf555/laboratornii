using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ElectroinicShop.DatabaseContext;

namespace ElectroinicShop;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void OpenMainWindow(object sender, RoutedEventArgs e)
    {
        string username = UsernameTB.Text;
        string password = PasswordTB.Text;

        bool isUsernameEmpty = string.IsNullOrWhiteSpace(username);
        if (isUsernameEmpty)
        {
            MessageBox.Show("Логин не может быть пустым!", "Ошибка");
            return;
        }

        bool isPasswordEmpty = string.IsNullOrWhiteSpace(password);
        if (isPasswordEmpty)
        {
            MessageBox.Show("Пароль не может быть пустым!", "Ошибка");
            return;
        }
        using (ApplicationDbContext dbContext = new ApplicationDbContext())
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                MessageBox.Show("ВЫ зашли!", "Успех");
                Close();
                return;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }

    private void OpenRegistrationWindow(object sender, RoutedEventArgs e)
    {
        Registrationwindow registrationwindow = new Registrationwindow();
        registrationwindow.ShowDialog();
    }
}
