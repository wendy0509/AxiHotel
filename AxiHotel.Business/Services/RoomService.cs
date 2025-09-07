using AxiHotel.Data.Models;
using AxiHotel.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Business
{
    public class RoomsService
    {
        private readonly IRoomRepository _repo;
        private static readonly HashSet<string> ValidRoomStatus =
        new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Disponible", "Ocupada", "Mantenimiento" };

        private static readonly HashSet<string> ValidHousekeeping =
        new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Limpia", "Sucia", "En limpieza" };


        public RoomsService(IRoomRepository repo) { _repo = repo; }
        public IEnumerable<Room> GetRooms() => _repo.GetAll();
        public Room Get(int id) => _repo.Get(id);
        public void ChangeStatus(int idRoom, string roomStatus)
        {
            if (!ValidRoomStatus.Contains(roomStatus)) throw new ArgumentException("Estado de habitación inválido");
            _repo.UpdateStatus(idRoom, roomStatus);
        }
        public void changeStatushousekeeping(int idRoom, string housekeepingStatus)
        {
            if (!ValidHousekeeping.Contains(housekeepingStatus)) throw new ArgumentException("Estado de limpieza inválido");
            _repo.UpdateStatusCleaning(idRoom, housekeepingStatus);
        }

    }
}