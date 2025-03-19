using PersonalBudget.DatabaseContext;
using PersonalBudget.Entity;


namespace PersonalBudget;

public partial class AddTransactionPage : ContentPage
{
    public AddTransactionPage()
    {
        InitializeComponent();
    }

    private void AddTransaction(object sender, EventArgs e)
    {
        string title = TitleEntry.Text;
        string description = DescriptionEntry.Text;
        string amount = AmountEntry.Text;

        bool isTitleEmpty = string.IsNullOrWhiteSpace(title);
        if (isTitleEmpty)
        {
            AppShell.Current.DisplayAlert("Ошибка", "Заголовок не может быть пустым", "ОК");
            return;
        }

        bool isDescriptionEmpty = string.IsNullOrWhiteSpace(description);
        if (isDescriptionEmpty)
        {
            AppShell.Current.DisplayAlert("Ошибка", "Описание не может быть пустым", "ОК");
            return;
        }

        bool isAmountEmpty = string.IsNullOrWhiteSpace(amount);
        if (isAmountEmpty)
        {
            AppShell.Current.DisplayAlert("Ошибка", "Цена не может быть пустая", "ОК");
            return;
        }

        decimal amountConvertedToDecimal = Convert.ToDecimal(amount);

        BdZatrat dbContext = new BdZatrat();
        dbContext.Transactions.Add(new TransactionEntity(title, description, amountConvertedToDecimal));
        dbContext.SaveChanges();

        AppShell.Current.DisplayAlert("Успех", "Затрата успешно добавлена", "ОК");
        AppShell.Current.GoToAsync("..", true);
    }
}