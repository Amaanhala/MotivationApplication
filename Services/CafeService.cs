using _6002CEM_AmaanHala.Model;
using System.Text.Json;

namespace _6002CEM_AmaanHala.Services;

public class CafeService
{
    HttpClient httpClient;
    public CafeService()
    {
        this.httpClient = new HttpClient();
    }

    List<Cafe> cafeList;
    public async Task<List<Cafe>> GetCafes()
    {
        if (cafeList?.Count > 0)
            return cafeList;

       
        using var stream = await FileSystem.OpenAppPackageFileAsync("librarycafe.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        cafeList = JsonSerializer.Deserialize<List<Cafe>>(contents);

        return cafeList;
    }
}