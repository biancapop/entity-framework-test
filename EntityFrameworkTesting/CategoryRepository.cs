using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkTesting
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        List<Category> MostrarCategorias();
        public Category SearchCategory(string name);

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

        public List<Category> MostrarCategorias()
        {
            return _databaseContext.Categories.ToList();
        }
        public Category SearchCategory(string name)
        {
            return _databaseContext.Categories.FirstOrDefault(t => t.Name == name);

        }
    }
}
