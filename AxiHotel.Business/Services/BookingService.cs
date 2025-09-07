using AxiHotel.Data.Models;
using AxiHotel.Data.Repositories;
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
        public BookingService(IBookingRepository repo) { _repo = repo; }
        public int AssignPlanToCustomer(int idCustomer, int idPlan, int idRoom, DateTime start, DateTime end,
          int people, string notes, double price, string statusPrice, int idReceptionist)
        {
            if (end <= start) throw new ArgumentException("La fecha fin debe ser mayor a inicio");
            var b = new Booking
            {
                DateStartBooking = start,
                DateEndBooking = end,
                HowManyPeopleBooking = people,
                DescriptionBooking = notes,
                PriceBooking = price,
                StatusPrice = statusPrice,
                IdCustomer = idCustomer,
                IdRoom = idRoom,
                IdPromotion = null,
                IdPlan = idPlan,
                IdWorker = idReceptionist
            };
            return _repo.Create(b);
        }
    }
}
