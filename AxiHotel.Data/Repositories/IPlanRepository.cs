using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Repositories
{
    public interface IPlanRepository
    {
        IEnumerable<HotelPlan> GetAll();
        IEnumerable<HotelPlan> Search(string filtro);
        void Add(HotelPlan plan);
        void Update(HotelPlan plan);
        void Delete(int id);
    }


}
