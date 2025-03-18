using System.Configuration;
using System.Data;
using System.Windows;
using desktop5lab.DataBaseContext;

namespace desktop5lab
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

        }
    }

}
