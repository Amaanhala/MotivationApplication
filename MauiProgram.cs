using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using _6002CEM_AmaanHala.Services;
using _6002CEM_AmaanHala.View;

namespace _6002CEM_AmaanHala;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseMauiMaps();

        builder.Logging.AddDebug();

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);

        builder.Services.AddSingleton<QuoteService>();
        builder.Services.AddSingleton<IDailyTaskService, DailyTaskService>();
        builder.Services.AddSingleton<CafeService>();


        builder.Services.AddSingleton<QuotesViewModel>();
        builder.Services.AddTransient<QuotesDetailsViewModel>();
        builder.Services.AddSingleton<DailyTaskListPageViewModel>();
        builder.Services.AddTransient<AddUpdateDailyTaskViewModel>();
        builder.Services.AddSingleton<CafeViewModel>();
        builder.Services.AddTransient<CafeDetailsViewModel>();

        builder.Services.AddSingleton<CafePage>();
        builder.Services.AddTransient<CafeDetailsPage>();
        builder.Services.AddSingleton<Timers>();
        builder.Services.AddTransient<AddUpdateDailyTask>();
        builder.Services.AddSingleton<DailyTaskListPage>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<SongsPage>();


        return builder.Build();
    }
}
