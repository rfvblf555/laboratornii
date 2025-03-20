using System.Text;

namespace HttpRequestsSending.Windows;
public partial class UpdateProduct : ContentPage
{
    public UpdateProduct()
    {
        InitializeComponent();
    }

    private async void Update_Clicked(object sender, EventArgs e)
    {
        string id = IdEntry.Text;
        string title = TitleEntry.Text;
        string description = DescriptionEntry.Text;

        bool isProductIdEmpty = string.IsNullOrWhiteSpace(id);
        if (isProductIdEmpty)
        {
            AppShell.Current.DisplayAlert("Error", "Поле идентификатор товара не может быть пустым", "Ок");
            return;
        }

        bool isProductNameEmpty = string.IsNullOrWhiteSpace(title);
        if (isProductNameEmpty)
        {
            AppShell.Current.DisplayAlert("Error", "Поле название товара не можеть быть пустым", "Ок");
            return;
        }

        bool isProductCostEmpty = string.IsNullOrWhiteSpace(description);
        if (isProductCostEmpty)
        {
            AppShell.Current.DisplayAlert("Error", "Поле цена товара не можеть быть пустым", "Ок");
            return;
        }

        var data = new { Title = title, Description = description };
        string json = System.Text.Json.JsonSerializer.Serialize(data);


        StringContent payload = new StringContent(json, Encoding.UTF8, "application/json");


        HttpClient client = new HttpClient();
        HttpResponseMessage responce = await client.PostAsync("product", payload);



        if (responce.StatusCode == System.Net.HttpStatusCode.InternalServerError)
        {

            string message = await responce.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            return;
        }
        if (responce.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {

            string message = await responce.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            return;
        }
        if (responce.IsSuccessStatusCode)
        {


            AppShell.Current.DisplayAlert("Успех", "Товар успешно обновлен", "Ок");

            AppShell.Current.GoToAsync("..", true);

        }


    }

}