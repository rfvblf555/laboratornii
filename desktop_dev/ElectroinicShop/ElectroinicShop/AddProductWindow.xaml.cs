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
using ElectroinicShop.DatabaseContext;
using ElectroinicShop.Entities;

namespace ElectroinicShop;
public partial class AddProductWindow : Window
{
    public AddProductWindow()
    {
        InitializeComponent();
    }

    private void AddProduct(object sender, RoutedEventArgs e)
    {
        string title = TitleTB.Text;
        string description = DescriptionTB.Text;
        string amount = AmountTB.Text;

        bool isTitleEmpty = string.IsNullOrWhiteSpace(title);
        if (isTitleEmpty)
        {
            MessageBox.Show("Заголовок товара не может быть пустым!", "Ошибка");
            return;
        }

        bool isDescriptionEmpty = string.IsNullOrWhiteSpace(description);
        if (isDescriptionEmpty)
        {
            MessageBox.Show("Описание товара не может быть пустым!", "Ошибка");
            return;
        }

        bool isAmountEmpty = string.IsNullOrWhiteSpace(amount);
        if (isAmountEmpty)
        {
            MessageBox.Show("Количество товара не может быть пустым!", "Ошибка");
            return;
        }

        ApplicationDbContext dbContext = new ApplicationDbContext();
        bool IsTitleAlreadyExist = dbContext.Products.Any(p => p.Title == title);
        if (IsTitleAlreadyExist)
        {
            MessageBox.Show("Товар с данным заголовком существует!", "Ошибка");
            return;
        }

        int amountConvertedToInteger = Convert.ToInt32(amount);
        ProductEntity product = new ProductEntity(title, description, amountConvertedToInteger);
        dbContext.Products.Add(product);
        dbContext.SaveChanges();
    }

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
