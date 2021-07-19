using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTesting
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

        public Category(string name)
        {
            Name = name;
        }
        //Constructor vacío requerido por EF
        public Category()
        {

        }
    }
}
