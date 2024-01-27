using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_History_app.Services;


namespace MAUI_History_app.ViewModel
{

    public partial class HistoriesViewModel : BaseViewModel
    {


        HistoryService historyService;
        public ObservableCollection<History> Histories { get; } = new();

        [ObservableProperty]
        string text;



        public HistoriesViewModel(HistoryService historyService)
        {

            Title = "History Tool Lite";
            this.historyService = historyService;

        }

        [RelayCommand]
        async Task GetHistoriesAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                historyService.SNstring = Text;
                if (Histories.Count != 0)
                {
                    Histories.Clear();
                    historyService.HistoryList.Clear();
                }

                var histories = await historyService.GetHistories();

                if (Histories.Count != 0)
                    Histories.Clear();

                foreach (var history in histories)
                    Histories.Add(history);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!",
                    $"Unable to get histories: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;

            }

        }


        [RelayCommand]
        async Task Navigate() => await Shell.Current.GoToAsync($"//{nameof(ScannerPage)}");

        //[RelayCommand]
        // public void  Tap()
        //{
        //    mainPage.CameraBarcodeReaderView_BarcodesDetected(object sender, BarcodeDetectionEventArgs e);
        //}
    }
}
