using _6002CEM_AmaanHala.View;

namespace _6002CEM_AmaanHala;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AddUpdateDailyTask), typeof(AddUpdateDailyTask));
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(CafeDetailsPage), typeof(CafeDetailsPage));

    }
}
