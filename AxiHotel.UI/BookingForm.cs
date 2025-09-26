using AxiHotel.Business;
using AxiHotel.Data.Models;
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
    public partial class BookingForm : UIForm

    {
        private readonly BookingService _service;
        private readonly bool _esAdmin;
        private readonly BookingService _bookingSrv;

        public BookingForm(BookingService service, bool esAdmin)
        {
            InitializeComponent();
            _service = service;
            _esAdmin = esAdmin;
            CargarReservas();
            // 🔹 Botones de agregar/eliminar visibles solo para admin
            if (SessionManager.CurrentWorker.JobTitle == "Administrador")
            {
                btnRegistrar.Visible = true;
                btnDelete.Visible = true;
                btnEditar.Visible = true;

                btnEditar2.Visible = false;
                btnRegistrar2.Visible = false;

            }
            else
            {
                btnEditar2.Visible = true;
                btnRegistrar2.Visible = true;
                btnDelete.Visible = false;
                btnRegistrar.Visible = false;
                btnEditar.Visible = false;

            }

        }


        // ✅ Método para refrescar la lista de reservas en el DataGridView
        private void CargarReservas(string filtro ="" )
        {
            try
            {
                var reservas = string.IsNullOrWhiteSpace(filtro) ?
                              _service.ObtenerTodas().ToList():
                              _service.SearchBookings(filtro);
                dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBookings.DataSource = reservas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar habitaciones: {ex.Message}");
            }

        }

        // ✅ Botón para eliminar reserva seleccionada
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow == null) return;

            try
            {
                int id = (int)dgvBookings.CurrentRow.Cells["IdBooking"].Value;
                _service.EliminarReserva(id);
                MessageBox.Show("Reserva eliminada 🗑️");
                CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ✅ Método para limpiar campos del formulario
        private void LimpiarFormulario()
        {
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtClienteId.Clear();
            txtHabitacionId.Clear();
            txtPromoId.Clear();
            txtPlanId.Clear();
            nudPersonas.Value = 1;
            cboEstado.SelectedIndex = 0;
        }
        private void DgvBookings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow == null) return;

            var id = (int)dgvBookings.CurrentRow.Cells["IdBooking"].Value;
            var b = _service.Get(id);
            if (b == null) return;

            txtIdBooking.Text = b.IdBooking.ToString(); // 👈 este campo es clave
            dtpInicio.Value = b.DateStartBooking;
            dtpFin.Value = b.DateEndBooking;
            nudPersonas.Value = b.HowManyPeopleBooking;
            txtDescripcion.Text = b.DescriptionBooking;
            txtPrecio.Text = b.PriceBooking.ToString("F2");
            cboEstado.Text = b.StatusPrice;
            txtClienteId.Text = b.IdCustomer.ToString();
            txtHabitacionId.Text = b.IdRoom.ToString();
            txtPromoId.Text = b.IdPromotion?.ToString();
            txtPlanId.Text = b.IdPlan?.ToString();
            txtIdWorker.Text = b.IdWorker.ToString();
        }
        // ✅ Botón para crear nueva reserva
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var booking = new Booking
                {
                    IdWorker=int.Parse(txtIdWorker.Text),
                    DateStartBooking = dtpInicio.Value,
                    DateEndBooking = dtpFin.Value,
                    HowManyPeopleBooking = (int)nudPersonas.Value,
                    DescriptionBooking = txtDescripcion.Text,
                    PriceBooking = double.Parse(txtPrecio.Text),
                    StatusPrice = cboEstado.Text,
                    IdCustomer = int.Parse(txtClienteId.Text),
                    IdRoom = int.Parse(txtHabitacionId.Text),
                    IdPromotion = string.IsNullOrWhiteSpace(txtPromoId.Text) ? (int?)null : int.Parse(txtPromoId.Text),
                    IdPlan = string.IsNullOrWhiteSpace(txtPlanId.Text) ? (int? )null : int.Parse(txtPlanId.Text)

                };

                _service.CrearReserva(booking);
                MessageBox.Show("Reserva creada con éxito ✅");
                CargarReservas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // ✅ Botón para editar reserva seleccionada
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow == null) return;

            try
            {
                var booking = new Booking
                {
                    IdBooking = int.Parse(txtIdBooking.Text), // 👈 importante
                    IdWorker = int.Parse(txtIdWorker.Text),
                    DateStartBooking = dtpInicio.Value,
                    DateEndBooking = dtpFin.Value,
                    HowManyPeopleBooking = (int)nudPersonas.Value,
                    DescriptionBooking = txtDescripcion.Text,
                    PriceBooking = double.Parse(txtPrecio.Text),
                    StatusPrice = cboEstado.Text,
                    IdCustomer = int.Parse(txtClienteId.Text),
                    IdRoom = int.Parse(txtHabitacionId.Text),
                    IdPromotion = string.IsNullOrWhiteSpace(txtPromoId.Text) ? (int?)null : int.Parse(txtPromoId.Text),
                    IdPlan = string.IsNullOrWhiteSpace(txtPlanId.Text) ? (int?)null : int.Parse(txtPlanId.Text)
                };

                _service.EditarReserva(booking);
                MessageBox.Show("Reserva editada correctamente ✏️");
                CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar2_Click(object sender, EventArgs e)
        {
            try
            {
                var booking = new Booking
                {
                    IdWorker = int.Parse(txtIdWorker.Text),
                    DateStartBooking = dtpInicio.Value,
                    DateEndBooking = dtpFin.Value,
                    HowManyPeopleBooking = (int)nudPersonas.Value,
                    DescriptionBooking = txtDescripcion.Text,
                    PriceBooking = double.Parse(txtPrecio.Text),
                    StatusPrice = cboEstado.Text,
                    IdCustomer = int.Parse(txtClienteId.Text),
                    IdRoom = int.Parse(txtHabitacionId.Text),
                    IdPromotion = string.IsNullOrWhiteSpace(txtPromoId.Text) ? (int?)null : int.Parse(txtPromoId.Text),
                    IdPlan = string.IsNullOrWhiteSpace(txtPlanId.Text) ? (int?)null : int.Parse(txtPlanId.Text)

                };

                _service.CrearReserva(booking);
                MessageBox.Show("Reserva creada con éxito ✅");
                CargarReservas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEditar2_Click(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow == null) return;

            try
            {
                var booking = new Booking
                {
                    IdBooking = int.Parse(txtIdBooking.Text), // 👈 importante
                    IdWorker = int.Parse(txtIdWorker.Text),
                    DateStartBooking = dtpInicio.Value,
                    DateEndBooking = dtpFin.Value,
                    HowManyPeopleBooking = (int)nudPersonas.Value,
                    DescriptionBooking = txtDescripcion.Text,
                    PriceBooking = double.Parse(txtPrecio.Text),
                    StatusPrice = cboEstado.Text,
                    IdCustomer = int.Parse(txtClienteId.Text),
                    IdRoom = int.Parse(txtHabitacionId.Text),
                    IdPromotion = string.IsNullOrWhiteSpace(txtPromoId.Text) ? (int?)null : int.Parse(txtPromoId.Text),
                    IdPlan = string.IsNullOrWhiteSpace(txtPlanId.Text) ? (int?)null : int.Parse(txtPlanId.Text)
                };

                _service.EditarReserva(booking);
                MessageBox.Show("Reserva editada correctamente ✏️");
                CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una habitación");
                return;
            }

            var id = (int)dgvBookings.CurrentRow.Cells["IdBooking"].Value;
            _service.EliminarReserva(id);
            MessageBox.Show("Reserva eliminada");
            CargarReservas();
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarReservas(txtBuscar.Text.Trim());
        }
    }
}
