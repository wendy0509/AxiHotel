using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Business
{
    //Clase estatica que sirve como memoria para manter la sesion activa de quien 
    //inicie sesion.
    public static class SessionManager
    {
        //Aquí se guarda el usuario que inició sesión.
        public static Worker CurrentWorker { get; set; }
        //Metodo que verifica que el usuario tenga un rol
        public static bool IsInRole(string roleName)
        {
            if (CurrentWorker == null || string.IsNullOrWhiteSpace(CurrentWorker.JobTitle)) return false;
            return CurrentWorker.JobTitle.Equals(roleName, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
