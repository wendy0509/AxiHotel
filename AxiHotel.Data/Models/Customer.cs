using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string NameCustomer { get; set; }
        public string LastCustomer { get; set; }
        public string IdentifyCustomer { get; set; }
        public string AddressCustomer { get; set; }
        public string PhoneCustomer { get; set; }
        public int? IdWorker { get; set; }

    }
}
