

namespace _6002CEM_AmaanHala.Services;
public class QuoteService
{
    HttpClient httpClient;
    public QuoteService()
    {
        this.httpClient = new HttpClient();
    }

    List<Quote> quoteList;
    public async Task<List<Quote>> GetQuotes()
    {
        if (quoteList?.Count > 0)
            return quoteList;


        using var stream = await FileSystem.OpenAppPackageFileAsync("allquotes.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        quoteList = JsonSerializer.Deserialize<List<Quote>>(contents);

        return quoteList;
    }
}