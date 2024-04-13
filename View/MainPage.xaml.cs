namespace _6002CEM_AmaanHala.View;

public partial class MainPage : ContentPage
{
    public MainPage(QuotesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

