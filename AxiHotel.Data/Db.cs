using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data
{
    internal static class Db
    {
        private static readonly string Cs = ConfigurationManager.ConnectionStrings["AxiHotel"].ConnectionString;
        public static SqlConnection Open() { var cn = new SqlConnection(Cs); cn.Open(); return cn; }
    }
}
