using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMPattern.Models;

namespace MVVMPattern.ViewModels;

public partial class RegistrationViewModel : ObservableObject
{
    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string password;

    [RelayCommand]
    private async Task GoToLoginPageAsync()
    {
        bool isNameEmpty = string.IsNullOrWhiteSpace(Name);
        if (isNameEmpty)
        {
            await AppShell.Current.DisplayAlert("Ошибка", "Имя пользователя пустое!", "OK");
            return;
        }

        bool isPasswordEmpty = string.IsNullOrWhiteSpace(Password);
        if (isPasswordEmpty)
        {
            await AppShell.Current.DisplayAlert("Ошибка", "Пароль пустой", "ОК");
            return;
        }

        bool isUserExist = AppData.Users.Any(x => x.Name == Name);
        if (isUserExist)
        {
            await AppShell.Current.DisplayAlert("Ошибка", "Пользователь с таким именем уже существует!", "ОК");
            return;
        }

        AppData.Users.Add(new User(Name, Password));
        await AppShell.Current.DisplayAlert("Успех", "Регистрация выполнена!", "ОК");
        await AppShell.Current.GoToAsync("//" + nameof(Views.LoginView), true);
    }
}