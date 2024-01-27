using MAUI_History_app.Services;
using ZXing.Net.Maui;

namespace MAUI_History_app;

public partial class MainPage : ContentPage
{
    HistoryService historyService;
    public MainPage(HistoriesViewModel viewModel, HistoryService historyService)
    {
        InitializeComponent();
        BindingContext = viewModel;
        //barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions();
        this.historyService = historyService;

    }




    //private void Button_Clicked(object sender, EventArgs e)
    //{
    //    CameraBarcodeReaderView_BarcodesDetected(sender, e);
    //}
}


//SAFE APP BACKUP

