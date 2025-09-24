using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Models
{
    public class Booking
    {
        public int IdBooking { get; set; }
        public DateTime DateStartBooking { get; set; }
        public DateTime DateEndBooking { get; set; }
        public int HowManyPeopleBooking { get; set; }
        public string DescriptionBooking { get; set; }
        public double PriceBooking { get; set; }
        public string StatusPrice { get; set; }
        public int IdCustomer { get; set; }
        public int IdRoom { get; set; }
        public int? IdPromotion { get; set; }
        public int? IdPlan { get; set; }
        public int IdWorker { get; set; }
    }
}
