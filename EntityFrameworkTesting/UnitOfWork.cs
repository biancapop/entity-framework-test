namespace EntityFrameworkTesting
{
    class UnitOfWork
    {
        public ITaskRepository Tasks { get; set; }
        public ICategoryRepository Categories { get; set; }

        public UnitOfWork()
        {
            DatabaseContext context = new DatabaseContext();
            context.Database.EnsureCreated();

            Tasks = new TaskRepository(context);
            Categories = new CategoryRepository(context);
        }
    }
}
