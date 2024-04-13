using _6002CEM_AmaanHala.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace _6002CEM_AmaanHala.ViewModel;

[QueryProperty(nameof(Cafe), "Cafe")]
public partial class CafeDetailsViewModel : BaseViewModel
{
    IMap map;
    public CafeDetailsViewModel(IMap map)
    {
        this.map = map;
    }

    [ObservableProperty]
    Cafe cafe;



    [RelayCommand]
    async Task OpenMap()
    {
        try
        {
            await map.OpenAsync(Cafe.Latitude, Cafe.Longitude, new MapLaunchOptions
            {
                Name = Cafe.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to launch maps: {ex.Message}");
            await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
        }
    }
}