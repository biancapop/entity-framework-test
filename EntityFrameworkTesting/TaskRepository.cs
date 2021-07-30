using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EntityFrameworkTesting
{
    public interface ITaskRepository
    {
        void Create(Task task);
        void Createcategory(Task task);

        void Delete(Task task);

        public Task SearchTask(int id);
        List<Task> Mostrar();
        public void Update(Task task);
        

    }


    class TaskRepository : ITaskRepository
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
        public void Createcategory(Task task)
        {
            _databaseContext.SaveChanges();
        }
        public List<Task> Mostrar()
        {
            return _databaseContext.Tasks.ToList();
        }
        public Task SearchTask(int id)
        {

           return (from a in _databaseContext.Tasks where a.Id == id select a).FirstOrDefault();
           //return _databaseContext.Tasks.FirstOrDefault(t => t.Name == name);
        }
        public void Delete(Task task)
        {

            _databaseContext.Remove(task);
            _databaseContext.SaveChanges();
            
        }
        public void Update (Task task)
        {
            _databaseContext.Tasks.Update(task);
            _databaseContext.SaveChanges();
        }
    }
}
