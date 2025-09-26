using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Models
{
    public class HotelPlan
    {
        public int IdPlan { get; set; }
        public int HowManyPeoplePlan { get; set; }
        public string DescriptionPlan { get; set; }
        public string NamePlan { get; set; }
        public int IdWorker {  get; set; }
    }
}
