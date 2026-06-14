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
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly StoreDbContext context;

        public SQLCustomerRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public Customer Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public Customer? GetById(int id)
        {
            return context.Customers
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers
                .AsNoTracking()
                .ToList();
        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = context.Customers.Find(id);
            if (customer == null) return;

            context.Customers.Remove(customer);
            context.SaveChanges();
        }
    }
    
}
