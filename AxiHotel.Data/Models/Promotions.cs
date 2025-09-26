using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Models
{
    public class Promotions
    {
        public int IdPromotion { get; set; }
        public DateTime DateStartPromotions { get; set; }
        public DateTime DateEndPromotions { get; set; }
        public string NamePromotions { get; set; }
        public string DescriptionPromotions { get; set; }
        public int IdWorker { get; set; }
    }
}
