using _6002CEM_AmaanHala.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _6002CEM_AmaanHala.ViewModel

{
    [QueryProperty(nameof(DailyTaskss), "DailyTaskss")]

    public partial class AddUpdateDailyTaskViewModel : ObservableObject
    {
        [ObservableProperty]
        private DailyTaskModel _dailyTaskss = new DailyTaskModel();


        private readonly IDailyTaskService _dailyTaskService;
        public AddUpdateDailyTaskViewModel(IDailyTaskService dailyTaskService)
        {
            _dailyTaskService = dailyTaskService;
        }


        [RelayCommand]
        public async void AddUpdateTask()
        {
            int response = -1;
            if (DailyTaskss.TasksID > 0)
            {
                response = await _dailyTaskService.UpdateDailyTask(DailyTaskss);
            }
            else
            {
                response = await _dailyTaskService.AddDailyTask(new Model.DailyTaskModel
                {
                    DailyTask = DailyTaskss.DailyTask,
                    TaskDescription = DailyTaskss.TaskDescription

                });
            }


            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Task added Successfully", "Go back to the main page", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Task not added", "Something went wrong", "Ok");
            }
        }


    }
}