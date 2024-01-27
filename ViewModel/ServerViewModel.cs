

using CommunityToolkit.Mvvm.ComponentModel;

using MAUI_History_app.Services;


namespace MAUI_History_app.ViewModel
{
    public partial class ServerViewModel : BaseViewModel

    {
        HistoryService historyService;

        [ObservableProperty]
        string servername;

        [ObservableProperty]
        string port;


        public ServerViewModel(HistoryService historyService)
        {

            this.historyService = historyService;

        }

        [RelayCommand]
        async Task SaveServerPort()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                if (Servername != null && Port != null)
                {
                    historyService.Serverstr = Servername;
                    historyService.Portstr = Port;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!",
                    $"Unable to save connection string: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;

            }

        }


    }
}
