using StoreSaleSystemUpdated.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSaleSystemUpdated.Application.Interfaces
{
    public interface ISaleRepository
    {
        Sale Add(Sale sale);
        Sale? GetById(int id);
        IEnumerable<Sale> GetAll();
        void Update(Sale sale);
    }
}
