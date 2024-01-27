

using CommunityToolkit.Mvvm.ComponentModel;


namespace MAUI_History_app.ViewModel;


public partial class BaseViewModel : ObservableObject
{

    public BaseViewModel()
    {

    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;


    public bool IsNotBusy => !IsBusy;

}
