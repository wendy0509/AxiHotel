using AxiHotel.Business;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxiHotel.Data.Repositories;
using AxiHotel.Data.Models;
using Sunny.UI;




namespace AxiHotel.UI
{
    public partial class RoomsForm : UIForm
    {
        private readonly RoomsService _srv;
        private readonly bool _esServicio;
        private readonly RoomsService _service; // servicio de habitaciones

        public RoomsForm(RoomsService srv, bool esServicio = false)
        {
            InitializeComponent();
            _srv = srv;
            _esServicio = esServicio;
            if (_esServicio)
            {
                btnBack.Visible = false;
                cmbRoomStatus.Visible = false;
                Disponibilitytext.Visible = false;
            }
            else
            {
                cmbHousekeeping.Visible = false;
                label4.Visible = false;

            }
        }

        private void LoadData()
        {
    
            try
            {
                // Obtener las habitaciones desde el servicio
                var rooms = _srv.GetRooms();

                // Cargar datos en el DataGridView
                dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvRooms.DataSource = rooms.ToList();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar habitaciones: {ex.Message}");
            }
        }

        private void btnVerSpecs_Click(object s, EventArgs e)
        {
            if (dgvRooms.CurrentRow == null) return;
            var id = (int)dgvRooms.CurrentRow.Cells["IdRoom"].Value;
            var r = _srv.Get(id);
            MessageBox.Show($"Tipo: {r.TypeRoom}\nDescripción: {r.DescriptionRoom}\n" +
                            $"Estado: {r.RoomStatus}\nLimpieza: {r.HousekeepingStatus}", "Especificaciones");
        }

        private void btnCambiarEstado_Click(object s, EventArgs e)
        {
           
            if (dgvRooms.CurrentRow == null) return;
            var id = (int)dgvRooms.CurrentRow.Cells["IdRoom"].Value;

            // Validar el rol del usuario actual
            if (SessionManager.CurrentWorker.JobTitle == "Recepcionista")
            {
                // Ejemplo: solo puede marcar la habitación como Libre u Ocupada
                if (cmbRoomStatus.Text == "Dsiponible" || cmbRoomStatus.Text == "Ocupada" || cmbRoomStatus.Text == "Mantenimiento")
                {
                    _srv.ChangeStatus(id, cmbRoomStatus.Text);
                }
                else
                {
                    MessageBox.Show("No tienes permiso para realizar este cambio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (SessionManager.CurrentWorker.JobTitle == "Servicio")
            {
                // Ejemplo: solo puede marcar la habitación como En limpieza o Lista para usar
                if (cmbHousekeeping.Text == "Limpia" || cmbHousekeeping.Text == "En Limpieza" || cmbHousekeeping.Text== "Sucia")
                {
                    _srv.changeStatushousekeeping(id, cmbHousekeeping.Text);
                }
                else
                {
                    MessageBox.Show("No tienes permiso para realizar este cambio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Tu rol no tiene permiso para cambiar estados.");
                return;
            }

            LoadData();
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            this.Close(); // vuelve al formulario padre (RecepcionistMainForm)
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart(); // reinicia la app y vuelve al login
        }

        private void Disponibilitytext_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
