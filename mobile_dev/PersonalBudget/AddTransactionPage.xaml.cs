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
            AppShell.Current.DisplayAlert("������", "��������� �� ����� ���� ������", "��");
            return;
        }

        bool isDescriptionEmpty = string.IsNullOrWhiteSpace(description);
        if (isDescriptionEmpty)
        {
            AppShell.Current.DisplayAlert("������", "�������� �� ����� ���� ������", "��");
            return;
        }

        bool isAmountEmpty = string.IsNullOrWhiteSpace(amount);
        if (isAmountEmpty)
        {
            AppShell.Current.DisplayAlert("������", "���� �� ����� ���� ������", "��");
            return;
        }

        decimal amountConvertedToDecimal = Convert.ToDecimal(amount);

        BdZatrat dbContext = new BdZatrat();
        dbContext.Transactions.Add(new TransactionEntity(title, description, amountConvertedToDecimal));
        dbContext.SaveChanges();

        AppShell.Current.DisplayAlert("�����", "������� ������� ���������", "��");
        AppShell.Current.GoToAsync("..", true);
    }
}