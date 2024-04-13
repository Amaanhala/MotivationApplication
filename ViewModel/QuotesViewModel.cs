using _6002CEM_AmaanHala.Services;
using _6002CEM_AmaanHala.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _6002CEM_AmaanHala.ViewModel;
public partial class QuotesViewModel : BaseViewModel
{
    public ObservableCollection<Quote> Quotes { get; } = new();
    QuoteService quoteService;
    public QuotesViewModel(QuoteService quoteService)
    {
        Title = "Quotes Finder";
        this.quoteService = quoteService;
    }

    [RelayCommand]
    async Task GoToDetails(Quote quote)
    {
        if (quote == null)
            return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Quote", quote }
        });
    }

    [RelayCommand]
    async Task GetQuotesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var quotes = await quoteService.GetQuotes();

            if (Quotes.Count != 0)
                Quotes.Clear();

            foreach (var quote in quotes)
                Quotes.Add(quote);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get quote: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}