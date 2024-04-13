namespace _6002CEM_AmaanHala.View;

public partial class CafeDetailsPage : ContentPage
{
    public CafeDetailsPage(CafeDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}