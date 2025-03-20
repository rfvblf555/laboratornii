using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpRequestsSending.Windows;

namespace HttpRequestsSending
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void GoToShowProductPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(Products), true);
        }

        private void GoToRemoveProductPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(RemovePage), true);
        }

        private void GoToAddProductPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(AddProduct), true);
        }

        private void GoToUpdateProductPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(UpdateProduct), true);
        }

        private void GoToShowProductByIdPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(ProductIdSearch), true);
        }

    }

}
