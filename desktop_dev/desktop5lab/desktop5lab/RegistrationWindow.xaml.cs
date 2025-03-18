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
using desktop5lab.DataBaseContext;
using desktop5lab.Entities;

namespace desktop5lab
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void CloseRegistrationWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoToMainWindow(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTB.Text;
            string lastName = LastNameTB.Text;
            string middleName = MiddleNameTB.Text;
            string login = LoginTB.Text;
            string password = PasswordPB.Password;
            string passwordRetry = PasswordRetryPB.Password;




            bool isFirstNameEmpty = string.IsNullOrWhiteSpace(firstName);
            if (isFirstNameEmpty)
            {
                MessageBox.Show("Имеются незаполненные поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isLastNameEmpty = string.IsNullOrWhiteSpace(lastName);
            if (isLastNameEmpty)
            {
                MessageBox.Show("Имеются незаполненные поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isMiddleNameEmpty = string.IsNullOrWhiteSpace(middleName);
            if (isMiddleNameEmpty)
            {
                MessageBox.Show("Имеются незаполненные поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            bool isLoginEmpty = string.IsNullOrWhiteSpace(login);
            if (isLoginEmpty)
            {
                MessageBox.Show("Имеются незаполненные поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isPasswordEmpty = string.IsNullOrWhiteSpace(password);
            if (isPasswordEmpty)
            {
                MessageBox.Show("Имеются незаполненные поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isPasswordRetryEmpty = string.IsNullOrWhiteSpace(passwordRetry);
            if (isPasswordRetryEmpty)
            {
                MessageBox.Show("Имеются незаполненные поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != passwordRetry)
            {
                MessageBox.Show("Пароли не совпадают", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ApplicationDbContext dbContext = new ApplicationDbContext();

            bool isLoginAlreadyExist = dbContext.People.Any(x => x.Login == login);
            if (isLoginAlreadyExist)
            {
                MessageBox.Show("Логин занят", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            dbContext.People.Add(new PersonEntity(firstName, lastName, middleName, login, password));
            dbContext.SaveChanges();

            MessageBox.Show("Успешно зарегистрированно", "Уведомление", MessageBoxButton.OK);

            Close();



        }
    }
}
