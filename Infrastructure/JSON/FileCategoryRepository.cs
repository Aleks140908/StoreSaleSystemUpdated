using StoreSaleSystemUpdated.Application.Interfaces;
using StoreSaleSystemUpdated.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSaleSystemUpdated.Infrastructure.JSON
{
    public class FileCategoryRepository : ICategoryRepository
    {
        private readonly FileStorage storage;

        public FileCategoryRepository(FileStorage storage)
        {
            this.storage = storage;
        }
        public Category Add(Category category)
        {
            if (storage.Categories.Any())
                category.Id = storage.Categories.Max(c => c.Id) + 1;
            else
                category.Id = 1;

            storage.Categories.Add(category);
            storage.Save();
            return category;
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category == null) return;

            storage.Categories.Remove(category);
            storage.Save();
        }

        public IEnumerable<Category> GetAll()
        {
            return storage.Categories;
        }

        public Category? GetById(int id)
        {
            return storage.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category category)
        {
            var existingCategory = GetById(category.Id);
            if (existingCategory == null) return;

            existingCategory.Name = category.Name;

            storage.Save();
        }
    }
}
