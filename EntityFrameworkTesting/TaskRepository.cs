using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTesting
{
    public interface ITaskRepository{
        void CreateTask(Task task);

    }


    class TaskRepository:ITaskRepository
    {
        private DatabaseContext _databaseContext;

        public TaskRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void CreateTask(Task task)
        {
            if (task != null) {
                _databaseContext.Tasks.Add(task);
                _databaseContext.SaveChanges();
            }
        }
    }
}
