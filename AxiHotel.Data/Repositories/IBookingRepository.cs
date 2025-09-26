using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Repositories
{
    public interface IBookingRepository
    {
        bool ClienteExiste(string identificacion);
        bool HabitacionDisponible(int idRoom, DateTime inicio, DateTime fin, int? idBookingExcluir = null);

        int Add(Booking booking);
        int Update(Booking b);
        int Delete(int idBooking);
        IEnumerable<Booking> GetAll();
        Booking Get(int id);
        IEnumerable<Booking> Search(string filtro);
    }
}
