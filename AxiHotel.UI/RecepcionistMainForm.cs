using AxiHotel.Business;
using AxiHotel.Business.Services;
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

        // Constructor que recibe el trabajador logueado
        public RecepcionistMainForm(Worker logged)
        {
            InitializeComponent();
            _logged = logged;
            // Validación de rol para mostrar/ocultar botones
            if (_logged.JobTitle == "Administrador")
            {
                // 🔓 Muestra todo si es administrador
                btnHabitaciones.Visible = true;
                btnClientes.Visible = true;
                btnReservas.Visible = true;
                btnTrabajadores.Visible = true;
                btnPromociones.Visible = true;
                btnPlanes.Visible = true;

                btnPlanes2.Visible = false;
                btnPromociones2.Visible = false;
            }
            else if (_logged.JobTitle == "Recepcionista")
            {
                // 🔐 Solo muestra lo que el recepcionista puede usar
                btnHabitaciones.Visible = true;
                btnClientes.Visible = true;
                btnReservas.Visible = true;
                btnPlanes2.Visible = true;
                btnPromociones2.Visible = true;

                // 🔒 Oculta lo que no debe ver
                btnTrabajadores.Visible = false;
                btnPromociones.Visible = false;
                btnPlanes.Visible = false;
            }

        }
        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            var roomsSrv = new RoomsService(new RoomRepository());
            var form = new RoomsForm(roomsSrv, false); // false porque es recepcionista
            form.Show();


        }

        private void btnClientes_Click(object s, EventArgs e)
        {
            var custSrv = new CustomersService(new CustomerRepository());
            var plansSrv = new PlansService(new PlanRepository());
            var bookSrv = new BookingService(new BookingRepository());
            new CustomersForm(_logged, custSrv, plansSrv, bookSrv).Show();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            var bookingSrv = new BookingService(new BookingRepository());
            var form = new BookingForm(bookingSrv, false); // false = recepcionista
            form.Show();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart(); // reinicia la app y vuelve al login
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            // Crear el repositorio de promociones
            var promotionsRepo = new PromotionsRepository();

            // Crear el servicio de promociones y pasarle el repositorio
            var promotionsSrv = new PromotionService();

            // Crear el formulario de promociones y pasarle el servicio
            var form = new Promociones();

            // Mostrar el formulario
            form.Show();
        }

        private void btnPromociones2_Click(object sender, EventArgs e)
        {
            // Crear el repositorio de promociones
            var promotionsRepo = new PromotionsRepository();

            // Crear el servicio de promociones y pasarle el repositorio
            var promotionsSrv = new PromotionService();

            // Crear el formulario de promociones y pasarle el servicio
            var form = new Promociones();

            // Mostrar el formulario
            form.Show();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {

        }

        private void btnTrabajadores_Click(object sender, EventArgs e)
        {

        }

        private void btnPlanes2_Click(object sender, EventArgs e)
        {

        }
    }
}
