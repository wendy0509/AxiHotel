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
    }
}
