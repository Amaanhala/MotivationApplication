using _6002CEM_AmaanHala.Model;
using _6002CEM_AmaanHala.Services;
using _6002CEM_AmaanHala.View;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace _6002CEM_AmaanHala.ViewModel;

public partial class CafeViewModel : BaseViewModel

{
    public ObservableCollection<Cafe> Cafes { get; } = new();
    CafeService cafeService;
    IConnectivity connectivity;


    public CafeViewModel(CafeService cafeService, IConnectivity connectivity)
    {
        Title = "Quiet Places";
        this.cafeService = cafeService;
        this.connectivity = connectivity;

    }

    [RelayCommand]
    async Task GetCafesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");
                return;
            }

            IsBusy = true;
            var cafes = await cafeService.GetCafes();

            if (Cafes.Count != 0)
                Cafes.Clear();

            foreach (var cafe in cafes)
                Cafes.Add(cafe);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to find cafes: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }


    [RelayCommand]
    async Task GoToCafesDetails(Cafe cafe)
    {
        if (cafe == null)
            return;

        await Shell.Current.GoToAsync(nameof(CafeDetailsPage), true, new Dictionary<string, object>
    {
        {"Cafe", cafe }
    });
    }
}