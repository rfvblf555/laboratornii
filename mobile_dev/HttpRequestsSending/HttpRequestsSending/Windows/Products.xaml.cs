using System.Net;
using System.Text.Json;
using HttpRequestsSending.Models;


namespace HttpRequestsSending.Windows;


public partial class Products : ContentPage
{
    public Products()
    {
        InitializeComponent();
        GetProductsAsync();
    }

    private async void GetProductsAsync()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://10.0.2.2:8080/api/");

        HttpResponseMessage response = await client.GetAsync("product");

        if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            return;
        }

        if (response.StatusCode == HttpStatusCode.OK)
        {
            string json = await response.Content.ReadAsStringAsync();
            List<ProductResponce> products = JsonSerializer.Deserialize<List<ProductResponce>>(json);

            ProductsCV.ItemsSource = products;


        }

    }
}