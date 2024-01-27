using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace MAUI_History_app.ViewModel
{
    public partial class ScannerViewModel : BaseViewModel
    {

        [RelayCommand]
        async Task Backbtn() => await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        //async Task Back() => await Shell.Current.GoToAsync("..");

    }
}
