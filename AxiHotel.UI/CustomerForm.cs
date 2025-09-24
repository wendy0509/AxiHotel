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
    public partial class CustomersForm : UIForm
    {
        private readonly Worker _logged;
        private readonly CustomersService _custSrv;
        private readonly PlansService _plansSrv;
        private readonly BookingService _bookingSrv;

        public CustomersForm(Worker logged, CustomersService custSrv, PlansService plansSrv, BookingService bookingSrv)
        {
            InitializeComponent();
            _logged = logged;
            _custSrv = custSrv;
            _plansSrv = plansSrv;
            _bookingSrv = bookingSrv;

          
        }
        

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid(string filtro = "")
        {
            try
            {
                var customers = string.IsNullOrWhiteSpace(filtro)
                    ? _custSrv.GetAll()
                    : _custSrv.Search(filtro);

                dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCustomers.DataSource = customers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) { 
    
            LoadGrid(txtBuscar.Text.Trim());

        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            

            try
            {
                var c = new Customer
                {
                    NameCustomer = txtNombre.Text.Trim(),
                    LastCustomer = txtApellido.Text.Trim(),
                    IdentifyCustomer = txtIdentificacion.Text.Trim(),
                    AddressCustomer = txtDireccion.Text.Trim(),
                    PhoneCustomer = txtTelefono.Text.Trim(),
                  
                };

                int newId = _custSrv.Register(c);
                MessageBox.Show($"Cliente registrado (ID {newId})");
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {


            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            var id = (int)dgvCustomers.CurrentRow.Cells["IdCustomer"].Value;
            var c = new Customer
            {
                IdCustomer = id,
                NameCustomer = txtNombre.Text.Trim(),
                LastCustomer = txtApellido.Text.Trim(),
                IdentifyCustomer = txtIdentificacion.Text.Trim(),
                AddressCustomer = txtDireccion.Text.Trim(),
                PhoneCustomer = txtTelefono.Text.Trim(),
            };

            _custSrv.Edit(c);
            MessageBox.Show("Cliente actualizado.");
            LoadGrid();
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;

            var id = (int)dgvCustomers.CurrentRow.Cells["IdCustomer"].Value;
            var c = _custSrv.Get(id);

            if (c == null) return;

            txtNombre.Text = c.NameCustomer;
            txtApellido.Text = c.LastCustomer;
            txtIdentificacion.Text = c.IdentifyCustomer;
            txtDireccion.Text = c.AddressCustomer;
            txtTelefono.Text = c.PhoneCustomer;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }


    }

}
