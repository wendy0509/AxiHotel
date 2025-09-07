using AxiHotel.Data.Models;
using AxiHotel.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Business
{
    public class PlansService
    {
        private readonly IPlanRepository _repo;
        public PlansService(IPlanRepository repo) { _repo = repo; }
        public IEnumerable<HotelPlan> GetAll() => _repo.GetAll();
    }
}
