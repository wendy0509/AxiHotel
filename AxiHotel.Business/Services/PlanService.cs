using AxiHotel.Data.Models;
using AxiHotel.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Business
{
    public class PlanService
    {
        private readonly PlanRepository _repo;

        public PlanService()
        {
            _repo = new PlanRepository();
        }

        public IEnumerable<HotelPlan> GetAll() => _repo.GetAll();

        public IEnumerable<HotelPlan> Search(string filtro) => _repo.Search(filtro);

        public void Add(HotelPlan plan) => _repo.Add(plan);

        public void Update(HotelPlan plan) => _repo.Update(plan);

        public void Delete(int id) => _repo.Delete(id);
    }
}
