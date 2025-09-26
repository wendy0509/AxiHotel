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
                txtDescription.Visible = false;
                txtHouse.Visible = false;
                txtType.Visible = false;
                txtStatus.Visible = false;
                btnDelete.Visible = false;
                btnAdd.Visible = false;
            }
            else
            {
                cmbHousekeeping.Visible = false;
                label4.Visible = false;
            }

            // 🔹 Botones de agregar/eliminar visibles solo para admin
            if (SessionManager.CurrentWorker.JobTitle == "Administrador")
            {
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                txtDescription.Visible = true;
                txtHouse.Visible = true;
                txtType.Visible = true;
                txtStatus.Visible = true;

                cmbHousekeeping.Visible = false;
                label4.Visible = false;
                cmbRoomStatus.Visible = false;
                Disponibilitytext.Visible=false;
                btnCambiarEstado.Visible = false;
            }
            else
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                txtDescription.Visible = false;
                txtHouse.Visible = false;
                txtType.Visible = false;
                txtStatus.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
            }
        }
    

        private void LoadData(string filtro = "")
        {

            try
            {
                var rooms = string.IsNullOrWhiteSpace(filtro) ?
                                _srv.GetRooms() :
                                _srv.Search(filtro);

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
                if (cmbRoomStatus.Text == "Disponible" || cmbRoomStatus.Text == "Ocupada" || cmbRoomStatus.Text == "Mantenimiento")
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
                if (cmbHousekeeping.Text == "Limpia" || cmbHousekeeping.Text == "En limpieza" || cmbHousekeeping.Text== "Sucia")
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var r = new Room
                {
                    TypeRoom = txtType.Text.Trim(),
                    DescriptionRoom = txtDescription.Text.Trim(),
                    RoomStatus = "Disponible",
                    HousekeepingStatus = "Limpia"
                };

                int newId = _srv.Add(r);
                MessageBox.Show($"Habitación registrada (ID {newId})");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una habitación");
                return;
            }

            var id = (int)dgvRooms.CurrentRow.Cells["IdRoom"].Value;
            _srv.Delete(id);
            MessageBox.Show("Habitación eliminada");
            LoadData();
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            LoadData(txtBuscar.Text.Trim());
        }

        private void cmbHousekeeping_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
