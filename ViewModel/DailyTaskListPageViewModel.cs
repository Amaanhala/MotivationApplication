using _6002CEM_AmaanHala.Services;
using _6002CEM_AmaanHala.View;

namespace _6002CEM_AmaanHala.ViewModel
{
    public partial class DailyTaskListPageViewModel : ObservableObject
    {
        public ObservableCollection<DailyTaskModel> Tasks { get; set; } = new ObservableCollection<DailyTaskModel>();

        private readonly IDailyTaskService _dailyTaskService;
        public DailyTaskListPageViewModel(IDailyTaskService dailyTaskService)
        {
            _dailyTaskService = dailyTaskService;

        }

        [RelayCommand]
        public async void GetTaskList()
        {

            var dailyTaskList = await _dailyTaskService.GetTaskList();
            if (dailyTaskList?.Count > 0)
            {
                Tasks.Clear();
                foreach (var dailyTask in dailyTaskList)
                {
                    Tasks.Add(dailyTask);
                }
            }
        }

        [RelayCommand]
        public async void AddUpdateTasks()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateDailyTask));
        }

        [RelayCommand]
        public async void DisplayAction(DailyTaskModel dailyTaskModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select", "OK", null, "Edit", "Remove", "Timer");
            if (response == "Edit")
            {
                var NavigateParam = new Dictionary<string, object>();
                NavigateParam.Add("DailyTaskss", dailyTaskModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateDailyTask), NavigateParam);
            }
            else if (response == "Timer")
            {
                await AppShell.Current.GoToAsync("///Timers");
            }

            else if (response == "Remove")
            {
                var removeResponse = await _dailyTaskService.RemoveDailyTask(dailyTaskModel);
                if (removeResponse > 0)
                {
                    GetTaskList();
                }
            }
        }

    }
}