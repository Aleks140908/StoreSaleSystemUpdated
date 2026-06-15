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
   
        public class SQLSaleItemRepository : ISaleItemRepository
        {
        private readonly StoreDbContext context;

        public SQLSaleItemRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public SaleItem Add(SaleItem item)
        {
            context.SaleItems.Add(item);
            context.SaveChanges();
            return item;
        }

        public SaleItem? GetById(int id)
        {
            return context.SaleItems
                .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<SaleItem> GetAll()
        {
            return context.SaleItems
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<SaleItem> GetBySaleId(int saleId)
        {
            return context.SaleItems
                .AsNoTracking()
                .Where(i => i.SaleId == saleId)
                .ToList();
        }

        public void Update(SaleItem item)
        {
           // context.SaleItems.Update(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = context.SaleItems.Find(id);
            if (item == null) return;

            context.SaleItems.Remove(item);
            context.SaveChanges();
        }
    }
    
}
