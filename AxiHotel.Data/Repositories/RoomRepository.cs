using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AxiHotel.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {

  
        public IEnumerable<Room> GetAll()
        {
            var list = new List<Room>();

            using (var cn = Db.Open())
            using (var cmd = new SqlCommand("SELECT IdRoom,DescriptionRoom,RoomStatus,HousekeepingStatus,TypeRoom,IdWorker FROM Room", cn))
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    list.Add(new Room
                    {
                        IdRoom = (int)rd["IdRoom"],
                        DescriptionRoom = rd["DescriptionRoom"].ToString(),
                        RoomStatus = rd["RoomStatus"].ToString(),
                        HousekeepingStatus = rd["HousekeepingStatus"].ToString(),
                        TypeRoom = rd["TypeRoom"].ToString(),
                        IdWorker = rd["IdWorker"] == DBNull.Value ? null : (int?)Convert.ToInt32(rd["IdWorker"])
                    });
                }
            }

            return list;
        }
        public Room Get(int id)
        {
            Room room = null;

            using (var cn = Db.Open())
            using (var cmd = new SqlCommand("SELECT IdRoom, DescriptionRoom, RoomStatus, HousekeepingStatus, TypeRoom, IdWorker FROM Room WHERE IdRoom = @id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        room = new Room
                        {
                            IdRoom = (int)rd["IdRoom"],
                            DescriptionRoom = rd["DescriptionRoom"].ToString(),
                            RoomStatus = rd["RoomStatus"].ToString(),
                            HousekeepingStatus = rd["HousekeepingStatus"].ToString(),
                            TypeRoom = rd["TypeRoom"].ToString(),
                            IdWorker = rd["IdWorker"] == DBNull.Value ? null : (int?)Convert.ToInt32(rd["IdWorker"])
                        };
                    }
                }
            }

            return room;
        }

        public void UpdateStatus(int idRoom, string roomStatus)
        {
            using (var cn = Db.Open())
            using (var cmd = new SqlCommand("UPDATE Room SET RoomStatus = @roomStatus WHERE IdRoom = @idRoom", cn))
            {
                cmd.Parameters.AddWithValue("@idRoom", idRoom);
                cmd.Parameters.AddWithValue("@roomStatus", roomStatus);

                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateStatusCleaning(int idRoom, string housekeepingStatus)
        {
            using (var cn = Db.Open())
            using (var cmd = new SqlCommand("UPDATE Room SET  HousekeepingStatus = @housekeepingStatus WHERE IdRoom = @idRoom", cn))
            {
                cmd.Parameters.AddWithValue("@idRoom", idRoom);

                cmd.Parameters.AddWithValue("@housekeepingStatus", housekeepingStatus);

                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<Room> Search(string filtro)
        {
            var list = new List<Room>();

            using (var cn = Db.Open())
            using (var cmd = new SqlCommand(@"SELECT IdRoom, DescriptionRoom, RoomStatus, 
                                             HousekeepingStatus, TypeRoom, IdWorker 
                                      FROM Room
                                      WHERE DescriptionRoom LIKE @filtro 
                                         OR TypeRoom LIKE @filtro
                                         OR RoomStatus LIKE @filtro 
                                         OR HousekeepingStatus LIKE @filtro", cn))
            {
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Room
                        {
                            IdRoom = (int)rd["IdRoom"],
                            DescriptionRoom = rd["DescriptionRoom"].ToString(),
                            RoomStatus = rd["RoomStatus"].ToString(),
                            HousekeepingStatus = rd["HousekeepingStatus"].ToString(),
                            TypeRoom = rd["TypeRoom"].ToString(),
                            IdWorker = rd["IdWorker"] == DBNull.Value ? null : (int?)Convert.ToInt32(rd["IdWorker"])
                        });
                    }
                }
            }

            return list;
        }

        public int Add(Room room)
        {
            using (var cn = Db.Open())

            using (var cmd = new SqlCommand(@"INSERT INTO Room(TypeRoom, DescriptionRoom, RoomStatus, HousekeepingStatus) 
            OUTPUT INSERTED.IdRoom
            VALUES (@type, @desc, @status, @housekeeping)", cn))
            {
                cmd.Parameters.AddWithValue("@type", room.TypeRoom);
                cmd.Parameters.AddWithValue("@desc", room.DescriptionRoom);
                cmd.Parameters.AddWithValue("@status", room.RoomStatus);
                cmd.Parameters.AddWithValue("@housekeeping", room.HousekeepingStatus);

                return (int)cmd.ExecuteScalar();
            }

        }

        public void Delete(int id)
        {
            using (var cn = Db.Open())

            using (var cmd = new SqlCommand(@"DELETE FROM Room WHERE IdRoom=@id", cn))
            { 
               
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                
            }
        }

    }
}
