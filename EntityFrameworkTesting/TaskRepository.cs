namespace EntityFrameworkTesting
{
    public interface ITaskRepository{
        void Create(Task task);

    }


    class TaskRepository:ITaskRepository
    {
        private DatabaseContext _databaseContext;

        public TaskRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Create(Task task)
        {
            if (task != null) {
                _databaseContext.Tasks.Add(task);
                _databaseContext.SaveChanges();
            }
        }
    }
}
