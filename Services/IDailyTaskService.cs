

namespace _6002CEM_AmaanHala.Services

{
	public interface IDailyTaskService
    {
        Task<List<DailyTaskModel>> GetTaskList();

        Task<int> AddDailyTask(DailyTaskModel dailyTaskModel);
        Task<int> RemoveDailyTask(DailyTaskModel dailyTaskModel);

        Task<int> UpdateDailyTask(DailyTaskModel dailyTaskModel);

    }
}