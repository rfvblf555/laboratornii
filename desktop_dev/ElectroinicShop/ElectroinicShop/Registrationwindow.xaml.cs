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
using ElectroinicShop.Entities;

namespace ElectroinicShop;

public partial class Registrationwindow : Window
{
    public Registrationwindow()
    {
        InitializeComponent();
    }

    private void OpenLoginWindow(object sender, RoutedEventArgs e)
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

        ApplicationDbContext dbContext = new ApplicationDbContext();
        bool IsUsernameAlreadyExist = dbContext.Users.Any(u => u.Name == username);
        if (IsUsernameAlreadyExist)
        {
            MessageBox.Show("Логин с данным именем существует!", "Ошибка");
            return;
        }
        UserEntity user = new UserEntity(username, password);
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        MessageBox.Show("Пользователь был создан!", "Успех");
        Close();
    }

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
