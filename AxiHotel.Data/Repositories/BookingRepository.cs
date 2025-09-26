using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            // ✅ Verificar si cliente existe
            public bool ClienteExiste(string identificacion)
            {
                using (var cn = Db.Open())
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Customer WHERE IdentifyCustomer=@ident", cn))
                {
                    cmd.Parameters.AddWithValue("@ident", identificacion);
                    var result = cmd.ExecuteScalar();
                    return result != null && Convert.ToInt32(result) > 0;
                }
            }

            // ✅ Verificar disponibilidad de la habitación
            public bool HabitacionDisponible(int idRoom, DateTime inicio, DateTime fin, int? idBookingExcluir = null)
            {
                using (var cn = Db.Open())
                {
                    string sql = @"
            SELECT COUNT(*) 
            FROM Booking
            WHERE IdRoom = @room
              AND IdBooking <> ISNULL(@idBookingExcluir, -1)
              AND (
                  (DateStartBooking <= @fin AND DateEndBooking >= @inicio)
              )";

                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@room", idRoom);
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);
                        cmd.Parameters.AddWithValue("@idBookingExcluir", (object)idBookingExcluir ?? DBNull.Value);

                        var result = (int)cmd.ExecuteScalar();
                        return result == 0; // true = disponible
                    }
                }
            }

            // ✅ Crear reserva
            public int Add(Booking booking)
            {
                using (var cn = Db.Open())
                using (var cmd = new SqlCommand(@"
            INSERT INTO Booking (
                DateStartBooking, DateEndBooking, HowManyPeopleBooking, DescriptionBooking,
                PriceBooking, StatusPrice, IdCustomer, IdRoom, IdPromotion, IdPlan, IdWorker
            )
            OUTPUT INSERTED.IdBooking
            VALUES (@ds,@de,@p,@desc,@price,@status,@c,@r,@promo,@plan,@w)", cn))
                {
                    cmd.Parameters.AddWithValue("@ds", booking.DateStartBooking);
                    cmd.Parameters.AddWithValue("@de", booking.DateEndBooking);
                    cmd.Parameters.AddWithValue("@p", booking.HowManyPeopleBooking);
                    cmd.Parameters.AddWithValue("@desc", (object)booking.DescriptionBooking ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", booking.PriceBooking);
                    cmd.Parameters.AddWithValue("@status", booking.StatusPrice);
                    cmd.Parameters.AddWithValue("@c", booking.IdCustomer);
                    cmd.Parameters.AddWithValue("@r", booking.IdRoom);
                    cmd.Parameters.AddWithValue("@promo", (object)booking.IdPromotion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@plan", (object)booking.IdPlan ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@w", booking.IdWorker);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            // ✅ Editar reserva
            public int Update(Booking b)
            {
                using (var cn = Db.Open())
                using (var cmd = new SqlCommand(@"
            UPDATE Booking SET 
                DateStartBooking=@ds, 
                DateEndBooking=@de, 
                HowManyPeopleBooking=@p, 
                DescriptionBooking=@desc, 
                PriceBooking=@price, 
                StatusPrice=@status, 
                IdRoom=@r, 
                IdPromotion=@promo, 
                IdPlan=@plan, 
                IdWorker=@w
            WHERE IdBooking=@id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", b.IdBooking);
                    cmd.Parameters.AddWithValue("@ds", b.DateStartBooking);
                    cmd.Parameters.AddWithValue("@de", b.DateEndBooking);
                    cmd.Parameters.AddWithValue("@p", b.HowManyPeopleBooking);
                    cmd.Parameters.AddWithValue("@desc", (object)b.DescriptionBooking ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", b.PriceBooking);
                    cmd.Parameters.AddWithValue("@status", b.StatusPrice);
                    cmd.Parameters.AddWithValue("@r", b.IdRoom);
                    cmd.Parameters.AddWithValue("@promo", (object)b.IdPromotion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@plan", (object)b.IdPlan ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@w", b.IdWorker);

                    return cmd.ExecuteNonQuery();
                }
            }

            // ✅ Eliminar reserva
            public int Delete(int idBooking)
            {
                using (var cn = Db.Open())
                using (var cmd = new SqlCommand("DELETE FROM Booking WHERE IdBooking=@id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", idBooking);
                    return cmd.ExecuteNonQuery();
                }
            }

            // ✅ Obtener todas
            public IEnumerable<Booking> GetAll()
            {
                var list = new List<Booking>();
                using (var cn = Db.Open())
                using (var cmd = new SqlCommand(@"
            SELECT IdBooking, DateStartBooking, DateEndBooking, 
                   HowManyPeopleBooking, DescriptionBooking, 
                   PriceBooking, StatusPrice, IdCustomer, IdRoom, 
                   IdPromotion, IdPlan, IdWorker
            FROM Booking", cn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Booking
                        {
                            IdBooking = (int)rd["IdBooking"],
                            DateStartBooking = (DateTime)rd["DateStartBooking"],
                            DateEndBooking = (DateTime)rd["DateEndBooking"],
                            HowManyPeopleBooking = (int)rd["HowManyPeopleBooking"],
                            DescriptionBooking = rd["DescriptionBooking"] == DBNull.Value ? null : rd["DescriptionBooking"].ToString(),
                            PriceBooking = Convert.ToDouble(rd["PriceBooking"]),
                            StatusPrice = rd["StatusPrice"].ToString(),
                            IdCustomer = (int)rd["IdCustomer"],
                            IdRoom = (int)rd["IdRoom"],
                            IdPromotion = rd["IdPromotion"] == DBNull.Value ? 0 : Convert.ToInt32(rd["IdPromotion"]),
                            IdPlan = rd["IdPlan"] == DBNull.Value ? 0 : Convert.ToInt32(rd["IdPlan"]),
                            IdWorker = (int)rd["IdWorker"]
                        });
                    }
                }
                return list;
            }

            // ✅ Obtener por Id
            public Booking Get(int id)
            {
                Booking booking = null;
                using (var cn = Db.Open())
                using (var cmd = new SqlCommand(@"
            SELECT IdBooking, DateStartBooking, DateEndBooking, 
                   HowManyPeopleBooking, DescriptionBooking, 
                   PriceBooking, StatusPrice, IdCustomer, IdRoom, 
                   IdPromotion, IdPlan, IdWorker
            FROM Booking WHERE IdBooking = @id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            booking = new Booking
                            {
                                IdBooking = (int)rd["IdBooking"],
                                DateStartBooking = (DateTime)rd["DateStartBooking"],
                                DateEndBooking = (DateTime)rd["DateEndBooking"],
                                HowManyPeopleBooking = (int)rd["HowManyPeopleBooking"],
                                DescriptionBooking = rd["DescriptionBooking"] == DBNull.Value ? null : rd["DescriptionBooking"].ToString(),
                                PriceBooking = Convert.ToDouble(rd["PriceBooking"]),
                                StatusPrice = rd["StatusPrice"].ToString(),
                                IdCustomer = (int)rd["IdCustomer"],
                                IdRoom = (int)rd["IdRoom"],
                                IdPromotion = rd["IdPromotion"] == DBNull.Value ? 0 : Convert.ToInt32(rd["IdPromotion"]),
                                IdPlan = rd["IdPlan"] == DBNull.Value ? 0 : Convert.ToInt32(rd["IdPlan"]),
                                IdWorker = (int)rd["IdWorker"]
                            };
                        }
                    }
                }
                return booking;
            }
            public IEnumerable<Booking> Search(string filtro)
            {
                var list = new List<Booking>();

                using (var cn = Db.Open())
                using (var cmd = new SqlCommand(@"
        SELECT b.IdBooking, b.DateStartBooking, b.DateEndBooking, 
               b.HowManyPeopleBooking, b.DescriptionBooking, 
               b.PriceBooking, b.StatusPrice, 
               b.IdCustomer,
               b.IdRoom, b.IdPromotion, b.IdPlan, b.IdWorker
        FROM Booking b
        INNER JOIN Customer c ON b.IdCustomer = c.IdCustomer
        WHERE b.DescriptionBooking LIKE @filtro
           OR b.StatusPrice LIKE @filtro
           OR CAST(b.IdCustomer AS VARCHAR) LIKE @filtro
           OR CAST(b.IdRoom AS VARCHAR) LIKE @filtro", cn)) // 🔹 búsqueda por Id también
                {
                    cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new Booking
                            {
                                IdBooking = (int)rd["IdBooking"],
                                DateStartBooking = Convert.ToDateTime(rd["DateStartBooking"]),
                                DateEndBooking = Convert.ToDateTime(rd["DateEndBooking"]),
                                HowManyPeopleBooking = (int)rd["HowManyPeopleBooking"],
                                DescriptionBooking = rd["DescriptionBooking"].ToString(),
                                PriceBooking = Convert.ToDouble(rd["PriceBooking"]),
                                StatusPrice = rd["StatusPrice"].ToString(),
                                IdCustomer = (int)rd["IdCustomer"],
                                IdRoom = (int)rd["IdRoom"],
                                IdPromotion = rd["IdPromotion"] == DBNull.Value ? null : (int?)rd["IdPromotion"],
                                IdPlan = rd["IdPlan"] == DBNull.Value ? null : (int?)rd["IdPlan"],
                                IdWorker = (int)rd["IdWorker"]
                            });
                        }
                    }
                }

                return list;
            }


        }

    }
}
