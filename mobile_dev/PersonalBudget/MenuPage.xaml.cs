using PersonalBudget.DatabaseContext;

namespace PersonalBudget;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();
        RefreshCollectionView();

    }

    private void GoToAddTransactionPage(object sender, EventArgs e)
    {
        AppShell.Current.GoToAsync(nameof(AddTransactionPage), true);
    }
    private void RefreshData(object sender, EventArgs e)
    {
        RefreshCollectionView();
        RefreshV.IsRefreshing = false;
    }

    private void RefreshCollectionView()
    {
        using (var dbContext = new BdZatrat())
        {
            var transactions = dbContext.Transactions.ToList();

            TransactionCL.ItemsSource = dbContext.Transactions.ToList();

            int totalItems = transactions.Count;

            decimal totalAmount = transactions.Sum(t => t.Amount);

            TotalItemsLabel.Text = $"Oбщее количество товаров: {totalItems}";
            TotalAmountLabel.Text = $"Общая сумма товаров: {totalAmount:C}";
        }
    }
}