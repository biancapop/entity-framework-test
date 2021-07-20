namespace EntityFrameworkTesting
{
    public interface ICategoryRepository
    {
        void Create(Category category);

    }

    public class CategoryRepository : ICategoryRepository
    {
        private DatabaseContext _databaseContext;

        public CategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Create(Category category)
        {
            if (category != null)
            {
                _databaseContext.Categories.Add(category);
                _databaseContext.SaveChanges();
            }
        }
    }
}
