﻿using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        IEnumerable<Customer> Search(string filtro);
        int Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);

    }

}
