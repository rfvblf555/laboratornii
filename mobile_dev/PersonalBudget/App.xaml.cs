using PersonalBudget.DatabaseContext;

namespace PersonalBudget
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            BdZatrat dbContext = new BdZatrat();
            dbContext.Database.EnsureCreated();
        }
    }
}
