using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Repositories
{
    public interface ICustomerRepository
    {
        int Add(Customer c);
        void Update(Customer c);
        IEnumerable<Customer> Search(string text); // filtrar por nombre/apellido/identificación/teléfono
        void SetTag(int idCustomer, string tag);   // opcional
    }
}
