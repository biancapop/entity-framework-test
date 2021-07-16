﻿using System.Collections.Generic;

namespace EntityFrameworkTesting
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
