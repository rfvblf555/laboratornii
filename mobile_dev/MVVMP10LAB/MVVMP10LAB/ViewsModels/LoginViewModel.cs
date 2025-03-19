using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVMP10LAB.Users;
using CommunityToolkit.Mvvm.Input;
using MVVMP10LAB.Views;


namespace MVVMP10LAB.ViewsModels;

public partial class LoginViewModel : ObservableObject
{

    [ObservableProperty]
    private string login;

    [ObservableProperty]
    private string password;

    [RelayCommand]
    private async Task CheckUser()
    {
        if (string.IsNullOrWhiteSpace(login))
        {
            await AppShell.Current.DisplayAlert("Error", "Поле логин не может быть пустым", "Ok");
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            await AppShell.Current.DisplayAlert("Error", "Поле пароли не может быть пустым", "Ok");
            return;
        }

        if (Bd.Users.Any(u => u.Login == login && u.Password == password))
        {
            AppShell.Current.GoToAsync(nameof(MainPage), true);
        }


        AppShell.Current.DisplayAlert("Ошибка", "Не верно введенны данные", "ОК");
        return;



    }
}