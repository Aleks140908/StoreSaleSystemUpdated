using Microsoft.EntityFrameworkCore;
using StoreSaleSystemUpdated.Application.Interfaces;
using StoreSaleSystemUpdated.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSaleSystemUpdated.Infrastructure.SQL
{
    public class SQLCategoryRepository : ICategoryRepository
    {

        private readonly StoreDbContext context;

        public SQLCategoryRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public Category Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }

        public Category? GetById(int id)
        {
            return context.Categories
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories
                .AsNoTracking()
                .ToList();
        }

        public void Update(Category category)
        {
           // context.Categories.Update(category);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null) return;

            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
