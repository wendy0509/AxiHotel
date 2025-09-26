using AxiHotel.Data.Models;
using AxiHotel.Data.Repositories;
using AxiHotel.Data.Repositories.xi.hotel.data.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AxiHotel.Business.Services
{
    public class PromotionService
    {

        private readonly PromotionsRepository _repo = new PromotionsRepository();

        public IEnumerable<Promotions> GetAll() => _repo.GetAll();

        public void Add(Promotions p) => _repo.Add(p);

        public void Update(Promotions p) => _repo.Update(p);

        public void Delete(int id) => _repo.Delete(id);

        public IEnumerable<Promotions> Search(string filtro) => _repo.Search(filtro);
    }
}
