using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMTransferData.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVMTransferData.ViewModels;

[QueryProperty(nameof(InputLesson), nameof(InputLesson))]

public partial class FirstViewModel : ObservableObject
{

    [ObservableProperty]
    private Lesson _inputLesson;

}
