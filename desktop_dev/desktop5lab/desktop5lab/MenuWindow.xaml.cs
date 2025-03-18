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

namespace desktop5lab
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            ApplicationDbContext dbContext = new ApplicationDbContext();
            NotesLV.ItemsSource = dbContext.Notes.ToList();



        }
        private void CloseMenuWindow(object sender, EventArgs e)
        {
            Close();
        }

    }
}

