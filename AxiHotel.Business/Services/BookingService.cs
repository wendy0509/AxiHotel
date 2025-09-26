using AxiHotel.Data.Models;
using AxiHotel.Data.Repositories;
using AxiHotel.Data.Repositories.xi.hotel.data.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Business
{
    public class BookingService
    {
        private readonly IBookingRepository _repo;

        public BookingService(IBookingRepository repo)
        {
            _repo = repo;
        }

        public bool ClienteExiste(string identificacion) => _repo.ClienteExiste(identificacion);

        // ✅ Crear reserva
        public int CrearReserva(Booking booking)
        {
            if (booking.DateStartBooking >= booking.DateEndBooking)
                throw new ArgumentException("La fecha de entrada debe ser anterior a la fecha de salida.");

            if (!_repo.HabitacionDisponible(booking.IdRoom, booking.DateStartBooking, booking.DateEndBooking))
                throw new ArgumentException("La habitación ya está reservada en esas fechas.");

            if (booking.HowManyPeopleBooking <= 0)
                throw new ArgumentException("La cantidad de personas debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(booking.StatusPrice))
                booking.StatusPrice = "Pendiente";

            return _repo.Add(booking);
        }


        // ✅ Editar reserva
        public int EditarReserva(Booking booking)
        {
            if (booking.DateStartBooking >= booking.DateEndBooking)
                throw new ArgumentException("La fecha de entrada debe ser anterior a la fecha de salida.");


            return _repo.Update(booking);
        }


        public int EliminarReserva(int idBooking) => _repo.Delete(idBooking);

        public IEnumerable<Booking> ObtenerTodas() => _repo.GetAll();

        public Booking Get(int id) => _repo.Get(id);
        public IEnumerable<Booking> SearchBookings(string filtro)
        {
            return _repo.Search(filtro);

        }
    }

}
