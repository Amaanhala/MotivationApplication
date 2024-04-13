using SQLite;


namespace _6002CEM_AmaanHala.Services
{
    public class DailyTaskService : IDailyTaskService
{
    private SQLiteAsyncConnection _dbConnection;
    public DailyTaskService()
    {
        if (_dbConnection == null)
        {
            DatabaseSetup();
        }
    }

    private async void DatabaseSetup()
    {
        if (_dbConnection == null)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DailyTask.db3");
            _dbConnection = new SQLiteAsyncConnection(dbPath);
            await _dbConnection.CreateTableAsync<DailyTaskModel>();
        }

    }

    public async Task<List<DailyTaskModel>> GetTaskList()
    {
        var dailyTaskList = await _dbConnection.Table<DailyTaskModel>().ToListAsync();
        return dailyTaskList;
    }

    public Task<int> AddDailyTask(DailyTaskModel dailyTaskModel)
    {
        return _dbConnection.InsertAsync(dailyTaskModel);
    }



    public Task<int> RemoveDailyTask(DailyTaskModel dailyTaskModel)
    {
        return _dbConnection.DeleteAsync(dailyTaskModel);
    }

    public Task<int> UpdateDailyTask(DailyTaskModel dailyTaskModel)
    {
        return _dbConnection.UpdateAsync(dailyTaskModel);
    }
}
}