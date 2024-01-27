namespace MAUI_History_app;

public partial class ServerPage : ContentPage
{
    public ServerPage(ServerViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}