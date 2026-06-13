using StoreSaleSystemUpdated.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSaleSystemUpdated.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        Category? GetById(int id);
        IEnumerable<Category> GetAll();
        void Update(Category category);
        void Delete(int id);

    }
}
