using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVMTransferData.Models;
using MVVMTransferData.Views;

namespace MVVMTransferData.ViewModels;

public partial class SecondViewModel : ObservableObject
{
    [ObservableProperty]
    private string _classroomName;
    [ObservableProperty]
    private string _teacherName;
    [ObservableProperty]
    private string _subjectName;
    [ObservableProperty]
    private TimeSpan _startAt;
    [ObservableProperty]
    private TimeSpan _endAt;


    [RelayCommand]
    private async Task GoToFirstViewAsync()
    {
        bool isClassroomNameEmpty = string.IsNullOrWhiteSpace(ClassroomName);
        if (isClassroomNameEmpty)
        {
            await AppShell.Current.DisplayAlert("Ошибка", "Номер аудитории не может быть пустым", "ОК");
            return;
        }

        bool isTeacherNameEmpty = string.IsNullOrWhiteSpace(TeacherName);
        if (isTeacherNameEmpty)
        {
            await AppShell.Current.DisplayAlert("Ошибка", "ФИО учителя не может быть пустым", "ОК");
            return;
        }

        bool isSubjectNameEmpty = string.IsNullOrWhiteSpace(SubjectName);
        if (isSubjectNameEmpty)
        {
            await AppShell.Current.DisplayAlert("Ошибка", "Название дисциплины не иожет быть пустым", "ОК");
            return;
        }
        Lesson lesson = new Lesson(ClassroomName, TeacherName, SubjectName, StartAt, EndAt);
        await AppShell.Current.GoToAsync("..", new Dictionary<string, object>
            {
                { nameof(FirstViewModel.InputLesson), lesson }
        });
    }
}
