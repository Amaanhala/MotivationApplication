
using _6002CEM_AmaanHala.Services;

namespace _6002CEM_AmaanHala.View;

public partial class Timers
{
    private readonly ProgressArc _progressArc;
    private DateTime _startTime;
    private readonly int _duration = 2;
    private double _progress;
    private CancellationTokenSource _cancellationTokenSource = new();
    private bool _timerRunning = false;
    private bool _timerPaused = false;

    private bool _timeIsUp;

    public Timers()
    {
        InitializeComponent();
        _progressArc = new ProgressArc();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ProgressButton.Text = "2";
        ProgressView.Drawable = _progressArc;
    }

    
    private void ProgressButton_OnClicked(object sender, EventArgs e)
    {
        if (!_timerRunning)
        {
            
            _startTime = DateTime.Now;
            _cancellationTokenSource = new CancellationTokenSource();
            _timeIsUp = false;
            _timerRunning = true;
            _progress = 0;
            UpdateArc();
        }
        else if (!_timerPaused)
        {
            
            _timerPaused = true;
            _cancellationTokenSource.Cancel();
            ProgressButton.IsEnabled = true;
        }
        else
        {
            
            _timerPaused = false;
            _startTime = DateTime.Now.AddMinutes(-_progress);
            _cancellationTokenSource = new CancellationTokenSource();
            UpdateArc();
        }
    }


    
    private void ResetButton_OnClicked(object sender, EventArgs e)
    {
        _cancellationTokenSource.Cancel();
        _timeIsUp = false;
        ResetView();
    }

    private async void UpdateArc()
    {

        string[] cheerupMessages = new[]
        {
        "You're doing great! Keep up the good work!",
        "You got this! Keep going!",
        "Keep pushing yourself, you'll reach your goals!",
        "You're making progress, don't give up now!",
        "You're amazing! Keep up the hard work!"
    };
        _timerRunning = true;

        while (!_cancellationTokenSource.Token.IsCancellationRequested)
        {
            TimeSpan elapsedTime = DateTime.Now - _startTime;
            int minutesRemaining = (int)(Math.Ceiling(_duration - elapsedTime.TotalMinutes));

            ProgressButton.Text = $"{minutesRemaining}";

            _progress = elapsedTime.TotalMinutes;
            _progress %= _duration;
            _progressArc.Progress = _progress / _duration;
            ProgressView.Invalidate();

            if (minutesRemaining == 0 && !_timeIsUp)
            {
                _timeIsUp = true;
                _cancellationTokenSource.Cancel();

                // Display alert and vibrate the device
                await DisplayAlert("Time's up!", "Take a break now!", "OK");
                var duration = TimeSpan.FromSeconds(2);
                Vibration.Vibrate(duration);

                
                await Task.Delay(TimeSpan.FromMinutes(2));

                if (_timeIsUp)
                {
                    _timeIsUp = false;

                    
                    int cheerupIndex = new Random().Next(0, cheerupMessages.Length);
                    await DisplayAlert("", cheerupMessages[cheerupIndex], "OK");

                    
                    bool userResponded = await DisplayAlert("Time's up!", "Start Working Again!", "OK", "Cancel");

                    if (userResponded)
                    {
                        
                        ResetView();
                        _startTime = DateTime.Now;
                        _cancellationTokenSource = new CancellationTokenSource();
                        UpdateArc();
                    }
                    else
                    {
                        ResetView();
                    }
                }
            }

            await Task.Delay(500);
        }
    }


    private void ResetView()
    {
        _cancellationTokenSource.Cancel();
        _timeIsUp = false;

        _timerRunning = false;
        _timerPaused = false;

        _startTime = DateTime.Now;
        int minutesRemaining = _duration;
        ProgressButton.Text = $"{minutesRemaining}";

        _progress = 0;
        _progressArc.Progress = 0;
        ProgressView.Invalidate();

        ProgressButton.IsEnabled = true;
    }


    private async void SongsButton_OnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SongsPage());
    }

    private async void MainButton_OnClicked(object sender, EventArgs e)
    {
        var viewModel = new QuotesViewModel(new QuoteService());
        await Navigation.PushAsync(new MainPage(viewModel));
    }

}
public class ProgressArc : IDrawable
{
    public double Progress { get; set; } = 60;
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Angle of the arc in degrees
        var endAngle = 90 - (int)Math.Round(Progress * 360, MidpointRounding.AwayFromZero);
        // Drawing code goes here

        canvas.StrokeColor = Color.FromRgba("16bbff");
        canvas.StrokeSize = 4;
        Debug.WriteLine($"The rect width is {dirtyRect.Width} and height is {dirtyRect.Height}");
        canvas.DrawArc(5, 5, (dirtyRect.Width - 10), (dirtyRect.Height - 10), 90, endAngle, false, false);
    }
}

