namespace _6002CEM_AmaanHala.View;

public partial class CafePage : ContentPage
{
    public CafePage(CafeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}