using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Models
{
    public class Booking
    {
        public int IdBooking;
        public DateTime DateStartBooking; 
        public DateTime DateEndBooking;
        public int HowManyPeopleBooking; 
        public string DescriptionBooking; 
        public double PriceBooking;
        public string StatusPrice;
        public int IdCustomer;
        public int IdRoom;
        public int? IdPromotion;
        public int IdPlan;
        public int IdWorker;
    }
}
