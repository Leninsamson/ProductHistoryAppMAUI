using MAUI_History_app.Services;
using ZXing.Net.Maui.Controls;

namespace MAUI_History_app;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
             .UseBarcodeReader()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<HistoryService>();
        builder.Services.AddSingleton<HistoriesViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<ServerPage>();
        builder.Services.AddTransient<ServerViewModel>();
        builder.Services.AddTransient<ScannerPage>();
        builder.Services.AddTransient<ScannerViewModel>();

        return builder.Build();
    }
}