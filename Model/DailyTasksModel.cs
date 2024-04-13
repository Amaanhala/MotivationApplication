using SQLite;


namespace _6002CEM_AmaanHala.Model
{
    public class DailyTaskModel
    {
        [SQLite.PrimaryKey, AutoIncrement]
        public int TasksID { get; set; }
        public string DailyTask { get; set; }
        public string TaskDescription { get; set; }
    }
}
