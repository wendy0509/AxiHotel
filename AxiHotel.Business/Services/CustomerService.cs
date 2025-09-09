using AxiHotel.Data.Models;
using AxiHotel.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Business
{
    public class CustomersService
    {
        private readonly ICustomerRepository _repo;
        public CustomersService(ICustomerRepository repo) { _repo = repo; }
        public int Register(Customer c)
        {
            if (string.IsNullOrWhiteSpace(c.NameCustomer)) throw new ArgumentException("Nombre requerido");
            if (string.IsNullOrWhiteSpace(c.LastCustomer)) throw new ArgumentException("Apellido requerido");
            if (string.IsNullOrWhiteSpace(c.IdentifyCustomer)) throw new ArgumentException("Identificación requerida");
            // podrías validar formato de teléfono, duplicados, etc.

            return _repo.Add(c);
        }

        public void Edit(Customer c)
        {
            if (c.IdCustomer <= 0) throw new ArgumentException("Cliente inválido");
            _repo.Update(c);
        }

        public IEnumerable<Customer> Filter(string text) => _repo.Search(text);

        public void Tag(int idCustomer, string tag) => _repo.SetTag(idCustomer, tag);

        public Customer Get(int id) => _repo.Get(id);
    }
}
