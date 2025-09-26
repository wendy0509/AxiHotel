using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Repositories
{
    public interface IPromotionsRepository
    {
        IEnumerable<Promotions> GetAll();
        void Add(Promotions p);
        void Update(Promotions p);
        void Delete(int id);
        IEnumerable<Promotions> Search(string filtro);
    }
}