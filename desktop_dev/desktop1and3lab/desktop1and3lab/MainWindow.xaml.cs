using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace desktop1and3lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenMenu(object sender, RoutedEventArgs e)
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
            Users user = ApplicationData.User.SingleOrDefault(x => x.Login == usersLogin);
            if (user == null)
            {
                MessageBox.Show("Несуществующий Логин", "Ошибка!");
                return;
            }
            if (user.Login == usersLogin && user.Password == usersPassword)
            {
                var MenuWindow = new MenuWindow();
                MenuWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Логин или пароль не совпадают!!!", "Ошибка!");
                return;
            }

        }

        private void OpenRegistration(object sender, RoutedEventArgs e)
        {
            var RegistrationWindow = new RegistrationWindow();
            RegistrationWindow.Show();
        }
    }
}
