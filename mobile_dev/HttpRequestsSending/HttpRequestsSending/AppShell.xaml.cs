using HttpRequestsSending.Windows;

namespace HttpRequestsSending
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddProduct), typeof(AddProduct));
            Routing.RegisterRoute(nameof(RemovePage), typeof(RemovePage));
            Routing.RegisterRoute(nameof(UpdateProduct), typeof(UpdateProduct));
            Routing.RegisterRoute(nameof(Products), typeof(Products));
            Routing.RegisterRoute(nameof(ProductIdSearch), typeof(ProductIdSearch));
        }
    }
}
