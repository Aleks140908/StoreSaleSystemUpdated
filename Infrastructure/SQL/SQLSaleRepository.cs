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
    public class SQLSaleRepository : ISaleRepository
    {
        private readonly StoreDbContext context;

        public SQLSaleRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public Sale Add(Sale sale)
        {
            context.Sales.Add(sale);
            context.SaveChanges();
            return sale;
        }

        public Sale? GetById(int id)
        {
            return context.Sales
                .Include(s => s.Items)
                .ThenInclude(i => i.Product)
                .Include(s => s.Customer)
                .Include(s => s.PromoCode)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Sale> GetAll()
        {
            return context.Sales
                .Include(s => s.Items)
                .ThenInclude(i => i.Product)
                .Include(s => s.Customer)
                .Include(s => s.PromoCode)
                .AsNoTracking()
                .ToList();
        }

        public void Update(Sale sale)
        {
           // context.Sales.Update(sale);
            context.SaveChanges();

        }
    }
}
