using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVMP10LAB.Users;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using MVVMP10LAB.Views;


namespace MVVMP10LAB.ViewsModels;


public partial class RegViewModel : ObservableObject
{
    [ObservableProperty]
    private string login;

    [ObservableProperty]
    private string password;


    [RelayCommand]
    private async Task AddUser()
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

        if (Bd.Users.Any(u => u.Login == login))
        {
            await AppShell.Current.DisplayAlert("Ошибка", "Такой пользовател уже существует", "ОК");
            return;
        }


        Bd.Users.Add(new User(login, password));
        await AppShell.Current.DisplayAlert("Готово", "Пользователь успешно зарегистрирован", "ОК");
        await AppShell.Current.GoToAsync("//AuthTab", true);
    }


}
