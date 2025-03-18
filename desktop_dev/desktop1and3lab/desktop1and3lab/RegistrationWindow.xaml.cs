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

namespace desktop1and3lab
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            string usersLogin = UsersLoginTB.Text;
            string usersPassword = UsersPasswordTB.Text;


            bool isUsersLoginEmpty = string.IsNullOrWhiteSpace(usersLogin);
            if (isUsersLoginEmpty)
            {
                MessageBox.Show("Логин не может быть пустым!", "Ошибка!");
                return;
            }


            bool isUsersPasswordEmpty = string.IsNullOrWhiteSpace(usersPassword);
            if (isUsersPasswordEmpty)
            {
                MessageBox.Show("Пароль не может быть пустым!", "Ошибка!");
                return;
            }

            bool IsUserLoginAlreadyExist = ApplicationData.User.Any(x => x.Login == usersLogin);
            if (IsUserLoginAlreadyExist)
            {
                MessageBox.Show("Пользователь с таким именем уже существует!", "Ошибка!");
                return;

            }
            ApplicationData.User.Add(new Users(usersLogin, usersPassword));
            MessageBox.Show("Вы успешно зарегестрировались!", "Успех");
            Close();
        }
    }
}