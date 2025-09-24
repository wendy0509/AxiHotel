using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        public IEnumerable<HotelPlan> GetAll()
        {
            var list = new List<HotelPlan>();

            using (var cn = Db.Open())
            {
                using (var cmd = new SqlCommand("SELECT * FROM HotelPlans", cn))
                {
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new HotelPlan
                            {
                                IdPlan = (int)rd["IdPlan"],
                                HowManyPeoplePlan = (int)rd["HowManyPeoplePlan"],
                                DescriptionPlan = rd["DescriptionPlan"].ToString(),
                                NamePlan = rd["NamePlan"].ToString(),
                                IdWorker = (int)rd["IdWorker"]
                            });
                        }
                    }
                }
            }

            return list;
        }
    }

}
