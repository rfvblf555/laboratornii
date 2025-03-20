using HttpRequestsSending.Models;
using System.Text.Json;
using System.Net;

namespace HttpRequestsSending.Windows;


public partial class ProductIdSearch : ContentPage
{
    public ProductIdSearch()
    {
        InitializeComponent();
    }

    private async void Search_Click(object sender, EventArgs e)
    {
        int productId = Convert.ToInt32(IdEntry.Text);

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://10.0.2.2:8080/api/");

        HttpResponseMessage response = await client.GetAsync($"product/{productId}");

        if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            return;
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            return;
        }

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            return;
        }

        if (response.StatusCode == HttpStatusCode.OK)
        {
            string json = await response.Content.ReadAsStringAsync();
            ProductResponce productResponce = JsonSerializer.Deserialize<ProductResponce>(json);
            if (productResponce == null)
            {
                Console.WriteLine("Ошибка товар оказался Null");
                return;
            }
            Id.Text = productResponce.Id.ToString();
            Title.Text = productResponce.Title;
            Description.Text = productResponce.Description;
            CreatedAt.Text = productResponce.CreatedAt;
            UpdatedAt.Text = productResponce.UpdateAt;


        }
    }
}