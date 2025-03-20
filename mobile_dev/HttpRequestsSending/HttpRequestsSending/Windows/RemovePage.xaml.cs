using System.Net;
using System.Text.Json;
using System.Text;
using HttpRequestsSending.Models;


namespace HttpRequestsSending.Windows;

public partial class RemovePage : ContentPage
{
    public RemovePage()
    {
        InitializeComponent();
    }

    private async void Remeove_Clicked(object sender, EventArgs e)
    {


        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://10.0.2.2:8080/api/");
        ProductRequest data = new ProductRequest("Новое название1", "Новое описание 2");
        string json = JsonSerializer.Serialize(data);
        StringContent payload = new StringContent(json, Encoding.UTF8, "application/json");

        int productId = Convert.ToInt32(IdEntry.Text);

        HttpResponseMessage response = await client.DeleteAsync($"product/{productId}");

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

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Товар удален");
            return;
        }

    }


}