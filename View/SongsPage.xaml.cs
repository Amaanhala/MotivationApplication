using CommunityToolkit.Maui.Views;
using System.Reflection;

namespace _6002CEM_AmaanHala.View;

public partial class SongsPage : ContentPage
{
    private readonly List<string> _songFiles = new List<string> { "Beats.mp3", "Relax.mp3", "Calmness.mp3", "Concentration.mp3", "Chill.mp3", "HipHop.mp3", "Mix.mp3", "SnowBackground.mp4" };
    private int _currentSong = 0;

    public SongsPage()
    {
        InitializeComponent();
        BindingContext = this;
        LoadMusicFile(_songFiles[_currentSong]);
    }

    public List<string> AudioFiles => _songFiles;

    private async Task LoadMusicFile(string fileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"_6002CEM_AmaanHala.Resources.Audio.{fileName}";

        string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var filePath = Path.Combine(appDataDirectory, fileName);

        if (!File.Exists(filePath))
        {
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream != null)
            {
                using var fileStream = File.Create(filePath);
                await stream.CopyToAsync(fileStream);
            }
        }

        mediaElement.Source = MediaSource.FromFile(filePath);
    }


    private void OnPlayButtonClick(object sender, EventArgs e)
    {
        mediaElement.Play();
    }

    private void OnPauseButtonClick(object sender, EventArgs e)
    {
        mediaElement.Pause();
    }

    private void OnStopButtonClick(object sender, EventArgs e)
    {
        mediaElement.Stop();
    }

    private async void OnNextButtonClick(object sender, EventArgs e)
    {
        NextSong();
        if (Path.GetExtension(_songFiles[_currentSong]).ToLower() == ".mp3")
        {
            mediaElement.Play();
        }
        else if (Path.GetExtension(_songFiles[_currentSong]).ToLower() == ".mp4")
        {
            mediaElement.Play();
        }
    }

    private async void NextSong()
    {
        _currentSong++;
        if (_currentSong >= _songFiles.Count)
        {
            _currentSong = 0;
        }
        await LoadMusicFile(_songFiles[_currentSong]);
    }

    private async void OnSongList(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is string selectedMusic)
        {
            mediaElement.Stop();
            _currentSong = _songFiles.IndexOf(selectedMusic);
            await LoadMusicFile(selectedMusic);
            if (Path.GetExtension(selectedMusic).ToLower() == ".mp3")
            {
                mediaElement.Play();
            }
            else if (Path.GetExtension(selectedMusic).ToLower() == ".mp4")
            {
                mediaElement.Play();
            }
        }
    }
}
