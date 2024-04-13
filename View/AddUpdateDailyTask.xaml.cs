namespace _6002CEM_AmaanHala.View;

public partial class AddUpdateDailyTask : ContentPage
{
    public AddUpdateDailyTask(AddUpdateDailyTaskViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}