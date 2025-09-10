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
        private readonly CustomerRepository _repo;

        public CustomersService(CustomerRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Customer> GetAll() => _repo.GetAll();

        public IEnumerable<Customer> Search(string filtro) =>
            _repo.Search(filtro);

        public Customer Get(int id) => _repo.Get(id);

        public int Register(Customer c) => _repo.Add(c);

        public void Edit(Customer c) => _repo.Update(c);
    }
}
