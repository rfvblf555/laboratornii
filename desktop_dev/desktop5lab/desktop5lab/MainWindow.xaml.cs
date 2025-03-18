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
using desktop5lab.DataBaseContext;

namespace desktop5lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenMenuWindow(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text;
            string password = PasswordPB.Password;

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

            ApplicationDbContext dbContext = new ApplicationDbContext();

            bool isAuthorizationSucceded = dbContext.People.Any(person => person.Login == login && person.Password == password);
            if (!isAuthorizationSucceded)
            {
                MessageBox.Show("Данные не совпадают", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var menuWindow = new MenuWindow();
            App.Current.MainWindow = menuWindow;
            menuWindow.Show();
            Close();
        }

        private void OpenRegistrationWindow(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }
    }
}