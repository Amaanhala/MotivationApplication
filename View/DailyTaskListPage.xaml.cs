namespace _6002CEM_AmaanHala.View;

public partial class DailyTaskListPage : ContentPage
{
    private DailyTaskListPageViewModel _viewModel;
    public DailyTaskListPage(DailyTaskListPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;

        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetTaskListCommand.Execute(null);
    }
}