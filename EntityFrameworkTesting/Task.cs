using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTesting
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //Constructor vacío requerido por EF
        public Task()
        {

        }
        public Task(string name, string content, Category category)
        {
            Name = name;
            Content = content;
            Category = category;
        }
    }
}
