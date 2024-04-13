using CommunityToolkit.Mvvm.ComponentModel;

namespace _6002CEM_AmaanHala.ViewModel;

[QueryProperty(nameof(Quote), "Quote")]
public partial class QuotesDetailsViewModel : BaseViewModel
{
    public QuotesDetailsViewModel()
    {
    }

    [ObservableProperty]
    Quote quote;
}