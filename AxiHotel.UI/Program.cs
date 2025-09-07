using AxiHotel.Business;
using AxiHotel.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxiHotel.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var login = new LoginForm())
            {
                var dr = login.ShowDialog();
                if (dr != DialogResult.OK)
                {
                    // usuario cerró / canceló login
                    return;
                }
            }

            // En este punto SessionManager.CurrentWorker ya debe estar seteado
            var role = SessionManager.CurrentWorker?.JobTitle?.ToLowerInvariant() ?? "";

            if (role.Contains("admin") || role.Contains("administrador"))
            {
                Application.Run(new AdminForm());
            }
            else if (role.Contains("recep") || role.Contains("recepcionista"))
            {
                Application.Run(new RecepcionistMainForm());

            }
            else if (role.Contains("serv") || role.Contains("servicio"))
            {
                // servicio entra directo a RoomsForm
                var roomsSrv = new RoomsService(new RoomRepository());
                Application.Run(new RoomsForm(roomsSrv, true)); // true porque es servicio
            }
            else
            {
                MessageBox.Show("Rol no reconocido. Consulte con el administrador.", "Rol inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Run(new LoginForm()); // fallback
            }
        }
    }

}
