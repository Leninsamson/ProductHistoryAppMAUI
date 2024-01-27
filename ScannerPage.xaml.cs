

using MAUI_History_app.Services;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace MAUI_History_app;

public partial class ScannerPage : ContentPage
{
    HistoryService historyService;
    public ScannerPage(ScannerViewModel vm, HistoryService historyService)
    {
        InitializeComponent();

        //barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions();
        this.historyService = historyService;
        BindingContext = vm;

    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {

        Dispatcher.Dispatch(() =>
        {

            //historyService.Barcode = $"{e.Results[0].Value} {e.Results[0].Format}";
            barcodeResult.Text = $"{e.Results[0].Value} {e.Results[0].Format}";

        });
    }




    //public ScannerPage()
    //{
    //   void CameraBarcodeReaderView_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    //    {
    //        Dispatcher.Dispatch(() =>
    //        {

    //            historyService.Barcode = $"{e.Results[0].Value} {e.Results[0].Format}";

    //        });
    //    }
    //}

}

