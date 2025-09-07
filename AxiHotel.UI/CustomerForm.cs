using AxiHotel.Business;
using AxiHotel.Data.Models;
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
    public partial class CustomersForm : Form
    {
        private readonly Worker _logged;
        private readonly CustomersService _cust;
        private readonly PlansService _plans;
        private readonly BookingService _book;

        public CustomersForm(Worker logged, CustomersService c, PlansService p, BookingService b)
        {
            InitializeComponent();
            _logged = logged; _cust = c; _plans = p; _book = b;
            LoadGrid();
        }

        private void LoadGrid() { dgvCustomers.DataSource = _cust.Filter("").ToList(); }

        private void txtBuscar_TextChanged(object s, EventArgs e)
        {
            dgvCustomers.DataSource = _cust.Filter(txtBuscar.Text).ToList();
        }

        private void btnRegistrar_Click(object s, EventArgs e)
        {
            var c = new Customer
            {
                NameCustomer = txtNombre.Text,
                LastCustomer = txtApellido.Text,
                IdentifyCustomer = txtIdentificacion.Text,
                AddressCustomer = txtDireccion.Text,
                PhoneCustomer = txtTelefono.Text,
                IdWorker = _logged.IdWorker
            };
            var newId = _cust.Register(c);
            MessageBox.Show($"Cliente registrado con Id {newId}");
            LoadGrid();
        }

        private void btnEditar_Click(object s, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            var c = new Customer
            {
                IdCustomer = (int)dgvCustomers.CurrentRow.Cells["IdCustomer"].Value,
                NameCustomer = txtNombre.Text,
                LastCustomer = txtApellido.Text,
                IdentifyCustomer = txtIdentificacion.Text,
                AddressCustomer = txtDireccion.Text,
                PhoneCustomer = txtTelefono.Text,
                IdWorker = _logged.IdWorker
            };
            _cust.Edit(c); LoadGrid();
        }


    }
}
