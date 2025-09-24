using AxiHotel.Business;
using AxiHotel.Data.Models;
using AxiHotel.Data.Repositories;
using AxiHotel.Data.Repositories.xi.hotel.data.repositories;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxiHotel.UI
{
    public partial class RecepcionistMainForm : UIForm
    {
        private readonly Worker _logged;


        // 🔹 Constructor que recibe Worker y connectionString
        public RecepcionistMainForm()
        {
            InitializeComponent();


        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            var roomsSrv = new RoomsService(new RoomRepository());
            var form = new RoomsForm(roomsSrv, false); // false porque es recepcionista
            form.ShowDialog();


        }

        private void btnClientes_Click(object s, EventArgs e)
        {
            var custSrv = new CustomersService(new CustomerRepository());
            var plansSrv = new PlansService(new PlanRepository());
            var bookSrv = new BookingService(new BookingRepository());
            new CustomersForm(_logged, custSrv, plansSrv, bookSrv).ShowDialog();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            var bookingSrv = new BookingService(new BookingRepository());
            var form = new BookingForm(bookingSrv, false); // false = recepcionista
            form.ShowDialog();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart(); // reinicia la app y vuelve al login
        }
    }
}
