namespace _6002CEM_AmaanHala.View;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(QuotesDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}