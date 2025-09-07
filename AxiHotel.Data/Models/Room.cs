using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Models
{
    public class Room
    {
        public int IdRoom { get; set; }
        public string DescriptionRoom { get; set; }
        public string RoomStatus { get; set; } 
        public string HousekeepingStatus { get; set; }
        public string TypeRoom { get; set; }
        public int? IdWorker;
    }
}
