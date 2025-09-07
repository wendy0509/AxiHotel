using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Repositories
{
    namespace xi.hotel.data.repositories
    {
        public class BookingRepository : IBookingRepository
        {
            public int Create(Booking b)
            {
                using (var cn = Db.Open())
                {
                    using (var cmd = new SqlCommand(@"
                INSERT INTO Booking (
                  DateStartBooking, DateEndBooking, HowManyPeopleBooking, DescriptionBooking,
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

                        var result = cmd.ExecuteScalar();
                        return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }
        }
    }
}
