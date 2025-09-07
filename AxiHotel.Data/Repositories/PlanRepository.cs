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

    // Booking
    public class BookingRepository : IBookingRepository
    {
        public int Create(Booking b)
        {
            using (var cn = Db.Open())
            {
                using (var cmd = new SqlCommand(@"
                INSERT INTO Booking (DateStartBooking, DateEndBooking, HowManyPeopleBooking, DescriptionBooking,
                  PriceBooking, StatusPrice, IdCustomer, IdRoom, IdPromotion, IdPlan, IdWorker)
                OUTPUT INSERTED.IdBooking
                VALUES (@ds,@de,@p,@desc,@price,@status,@c,@r,@promo,@plan,@w)", cn))
                {
                    cmd.Parameters.AddWithValue("@ds", b.DateStartBooking);
                    cmd.Parameters.AddWithValue("@de", b.DateEndBooking);
                    cmd.Parameters.AddWithValue("@p", b.HowManyPeopleBooking);
                    cmd.Parameters.AddWithValue("@desc", (object)b.DescriptionBooking ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", b.PriceBooking);
                    cmd.Parameters.AddWithValue("@status", b.StatusPrice);
                    cmd.Parameters.AddWithValue("@c", b.IdCustomer);
                    cmd.Parameters.AddWithValue("@r", b.IdRoom);
                    cmd.Parameters.AddWithValue("@promo", (object)b.IdPromotion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@plan", b.IdPlan);
                    cmd.Parameters.AddWithValue("@w", b.IdWorker);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
