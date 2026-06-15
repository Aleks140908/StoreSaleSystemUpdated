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
    public class SQLProductRepository : IProductRepository
    {
        private readonly StoreDbContext context;

        public SQLProductRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public Product Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product? GetById(int id)
        {
            return context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products
                .AsNoTracking()
                .ToList();
        }

        public void Update(Product product)
        {
           // context.Products.Update(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return;

            context.Products.Remove(product);
            context.SaveChanges();
        }

        public Product? GetByCode(string code)
        {
            return context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.Code == code);
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            return context.Products
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public IEnumerable<Product> GetActive()
        {
            return context.Products
                .AsNoTracking()
                .Where(p => p.IsActive)
                .ToList();
        }
    }
}
