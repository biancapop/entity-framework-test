namespace EntityFrameworkTesting
{
    public interface ITaskRepository{
        void Create(Task task);

        void DeleteTask(Task task);

        void SearchTask(Task task);

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
            if (task != null)
            {
                _databaseContext.Tasks.Add(task);
                _databaseContext.SaveChanges();
            }
        }
        public void DeleteTask(Task task)
        {
            _databaseContext.Tasks.Remove(task);
            _databaseContext.SaveChanges();
        }
        public void SearchTask(Task task)
        {

            _databaseContext.Tasks.Find();
           
       
        }
    }
}
