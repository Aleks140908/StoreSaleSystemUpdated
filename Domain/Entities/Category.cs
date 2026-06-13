using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSaleSystemUpdated.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public Category() { }
        public Category(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Трябва да въведете името на категорията!");
            Name = name;
        }
    }
}
