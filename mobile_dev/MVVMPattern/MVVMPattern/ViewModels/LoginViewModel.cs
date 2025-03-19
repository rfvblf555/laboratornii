using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMPattern.Models;
namespace MVVMPattern.ViewModels;

public partial class LoginViewModel : ObservableObject
{

    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string password;

    [RelayCommand]
    private async Task GoToMainPageAsync()
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

        bool isLoginSucceded = AppData.Users.Any(x => x.Name == Name && Password == x.Password);
        if (!isLoginSucceded)
        {
            await AppShell.Current.DisplayAlert("Ошибка", "Проверьте введенные данные, либо пройдите регистрацию!", "ОК");
            return;
        }

        await AppShell.Current.DisplayAlert("Успех", "Вход выполнен успешно!", "ОК");
        await AppShell.Current.GoToAsync(nameof(Views.MainView), true);
    }

    [RelayCommand]
    private async Task GoToRegistrationPageAsync()
    {
        await AppShell.Current.GoToAsync(nameof(Views.RegistrationView), true);

    }

}