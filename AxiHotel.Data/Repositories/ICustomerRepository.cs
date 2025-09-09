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
        Customer Get(int id);
        IEnumerable<Customer> Search(string text);
        void SetTag(int idCustomer, string tag);
    }
}
