using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Repositories
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Room Get(int id);
        void UpdateStatus(int idRoom, string roomStatus);

        void UpdateStatusCleaning(int idRoom, string housekeepingStatus);
        int Add(Room room);
        void Delete(int idRoom);
        IEnumerable<Room> Search(string filtro);

    }

}
