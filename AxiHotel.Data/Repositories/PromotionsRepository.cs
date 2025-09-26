using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxiHotel.Data.Repositories
{
    namespace xi.hotel.data.repositories
    {
        public class PromotionsRepository : IPromotionsRepository
        {
            public IEnumerable<Promotions> GetAll()
            {
                var list = new List<Promotions>();

                using (var cn = Db.Open())
                using (var cmd = new SqlCommand("SELECT * FROM Promotions", cn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Promotions
                        {
                            IdPromotion = (int)rd["IdPromotion"],
                            DateStartPromotions = Convert.ToDateTime(rd["DateStartPromotions"]),
                            DateEndPromotions = Convert.ToDateTime(rd["DateEndPromotions"]),
                            DescriptionPromotions = rd["DescriptionPromotions"].ToString(),
                            NamePromotions = rd["NamePromotions"].ToString(),
                            IdWorker = (int)rd["IdWorker"]
                        });
                    }
                }

                return list;
            }

            public void Add(Promotions p)
            {
                using (var cn = Db.Open())
                using (var cmd = new SqlCommand(@"
                INSERT INTO Promotions (DateStartPromotions, DateEndPromotions, DescriptionPromotions, NamePromotions, IdWorker)
                VALUES (@start, @end, @desc, @name, @worker)", cn))
                {
                    cmd.Parameters.AddWithValue("@start", p.DateStartPromotions);
                    cmd.Parameters.AddWithValue("@end", p.DateEndPromotions);
                    cmd.Parameters.AddWithValue("@desc", p.DescriptionPromotions);
                    cmd.Parameters.AddWithValue("@name", p.NamePromotions);
                    cmd.Parameters.AddWithValue("@worker", p.IdWorker);

                    cmd.ExecuteNonQuery();
                }
            }

            public void Update(Promotions p)
            {
                using (var cn = Db.Open())
                using (var cmd = new SqlCommand(@"
                UPDATE Promotions
                SET DateStartPromotions=@start, DateEndPromotions=@end,
                    DescriptionPromotions=@desc, NamePromotions=@name, IdWorker=@worker
                WHERE IdPromotion=@id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", p.IdPromotion);
                    cmd.Parameters.AddWithValue("@start", p.DateStartPromotions);
                    cmd.Parameters.AddWithValue("@end", p.DateEndPromotions);
                    cmd.Parameters.AddWithValue("@desc", p.DescriptionPromotions);
                    cmd.Parameters.AddWithValue("@name", p.NamePromotions);
                    cmd.Parameters.AddWithValue("@worker", p.IdWorker);

                    cmd.ExecuteNonQuery();
                }
            }

            public void Delete(int id)
            {
                using (var cn = Db.Open())
                {
                    using (var cmd = new SqlCommand("DELETE FROM Promotions WHERE IdPromotion = @ID", cn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("✅ Promoción eliminada correctamente.",
                                            "Éxito",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        catch (SqlException ex)
                        {
                            // Verificamos si el error es por violación de clave foránea
                            if (ex.Number == 547) // 547 = Foreign Key violation en SQL Server
                            {
                                MessageBox.Show(
                                    "⚠️ Esta promoción está asociada a reservas u otros registros y no puede ser eliminada.",
                                    "Error de Eliminación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                            }
                            else
                            {
                                // Cualquier otro error lo mostramos normal
                                MessageBox.Show(
                                    "❌ Ocurrió un error al intentar eliminar la promoción: " + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                    }
                }
            }


            public IEnumerable<Promotions> Search(string filtro)
            {
                var list = new List<Promotions>();

                using (var cn = Db.Open())
                using (var cmd = new SqlCommand(@"
                SELECT * FROM Promotions
                WHERE CAST(IdPromotion AS VARCHAR) LIKE @filtro
                   OR NamePromotions LIKE @filtro
                   OR DescriptionPromotions LIKE @filtro
                   OR CAST(DateStartPromotions AS VARCHAR) LIKE @filtro
                   OR CAST(DateEndPromotions AS VARCHAR) LIKE @filtro
                   OR CAST(IdWorker AS VARCHAR) LIKE @filtro", cn))
                {
                    cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new Promotions
                            {
                                IdPromotion = (int)rd["IdPromotion"],
                                DateStartPromotions = Convert.ToDateTime(rd["DateStartPromotions"]),
                                DateEndPromotions = Convert.ToDateTime(rd["DateEndPromotions"]),
                                DescriptionPromotions = rd["DescriptionPromotions"].ToString(),
                                NamePromotions = rd["NamePromotions"].ToString(),
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
