using System.Text;
using System.Net;


namespace HttpRequestsSending.Windows;


public partial class AddProduct : ContentPage
{
    public AddProduct()
    {
        InitializeComponent();
    }

    private async void AddProduct_Cliked(object sender, EventArgs e)
    {
        string title = TitleEntry.Text;
        string description = DescriptionEntry.Text;

        bool isTitleEmpty = string.IsNullOrWhiteSpace(title);
        if (string.IsNullOrWhiteSpace(title))
        {
            AppShell.Current.DisplayAlert("Error", "Название не можеть быть пустым", "Ок");
            return;
        }

        bool isDescEmpty = string.IsNullOrWhiteSpace(description);
        if (string.IsNullOrWhiteSpace(description))
        {
            AppShell.Current.DisplayAlert("Error", "Описание не можеть быть пустым", "Ок");
            return;
        }

        HttpClient client = new HttpClient();


        client.BaseAddress = new Uri("http://10.0.2.2:8080/api/");


        var data = new { Title = title, Description = description };
        string json = System.Text.Json.JsonSerializer.Serialize(data);

        StringContent payload = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage responce = await client.PostAsync("product", payload);


        if (responce.StatusCode == HttpStatusCode.InternalServerError)
        {

            string message = await responce.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            return;
        }

        if (responce.StatusCode == HttpStatusCode.BadRequest)
        {

            string message = await responce.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            return;
        }

        if (responce.IsSuccessStatusCode)
        {

            AppShell.Current.DisplayAlert("Успех", "Товар успешно добавлен", "Ок");

            AppShell.Current.GoToAsync("..", true);
        }
    }
}