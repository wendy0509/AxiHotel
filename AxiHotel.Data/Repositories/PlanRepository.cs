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
            using (var cmd = new SqlCommand("SELECT * FROM HotelPlans", cn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    list.Add(new HotelPlan
                    {
                        IdPlan = (int)dr["IdPlan"],
                        HowManyPeoplePlan = (int)dr["HowManyPeoplePlan"],
                        DescriptionPlan = dr["DescriptionPlan"].ToString(),
                        NamePlan = dr["NamePlan"].ToString(),
                        IdWorker = (int)dr["IdWorker"]
                    });
                }
            }
            return list;
        }

        public IEnumerable<HotelPlan> Search(string filtro)
        {
            var list = new List<HotelPlan>();

            using (var cn = Db.Open())
            using (var cmd = new SqlCommand(@"
                SELECT * FROM HotelPlans
                WHERE NamePlan LIKE @filtro
                   OR DescriptionPlan LIKE @filtro
                   OR HowManyPeoplePlan LIKE @filtro
                   OR IdWorker LIKE @filtro", cn))
            {
                cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new HotelPlan
                        {
                            IdPlan = (int)dr["IdPlan"],
                            HowManyPeoplePlan = (int)dr["HowManyPeoplePlan"],
                            DescriptionPlan = dr["DescriptionPlan"].ToString(),
                            NamePlan = dr["NamePlan"].ToString(),
                            IdWorker = (int)dr["IdWorker"]
                        });
                    }
                }
            }

            return list;
        }

        public void Add(HotelPlan plan)
        {
            using (var cn = Db.Open())
            using (var cmd = new SqlCommand(@"
                INSERT INTO HotelPlans (HowManyPeoplePlan, DescriptionPlan, NamePlan, IdWorker)
                VALUES (@people, @desc, @name, @worker)", cn))
            {
                cmd.Parameters.AddWithValue("@people", plan.HowManyPeoplePlan);
                cmd.Parameters.AddWithValue("@desc", plan.DescriptionPlan);
                cmd.Parameters.AddWithValue("@name", plan.NamePlan);
                cmd.Parameters.AddWithValue("@worker", plan.IdWorker);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(HotelPlan plan)
        {
            using (var cn = Db.Open())
            using (var cmd = new SqlCommand(@"
                UPDATE HotelPlans 
                SET HowManyPeoplePlan=@people, DescriptionPlan=@desc, NamePlan=@name, IdWorker=@worker
                WHERE IdPlan=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", plan.IdPlan);
                cmd.Parameters.AddWithValue("@people", plan.HowManyPeoplePlan);
                cmd.Parameters.AddWithValue("@desc", plan.DescriptionPlan);
                cmd.Parameters.AddWithValue("@name", plan.NamePlan);
                cmd.Parameters.AddWithValue("@worker", plan.IdWorker);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Db.Open())
            using (var cmd = new SqlCommand("DELETE FROM HotelPlans WHERE IdPlan=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // violación de foreign key
                    {
                        throw new Exception("Este plan tiene registros asociados y no puede eliminarse.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }

}
