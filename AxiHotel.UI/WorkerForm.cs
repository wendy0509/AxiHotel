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
    public partial class WorkerForm : UIForm
    {
        private readonly WorkerService _service;
        public WorkerForm()
        {

            InitializeComponent();
            _service = new WorkerService();
            LoadData();
        }
        private void LoadData()
        {
            dgvWorker.DataSource = _service.GetAll().ToList();
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var worker = new Worker
            {
                FullNameWorker = txtLastName.Text,
                IdentifyWorker = txtIdentifyWorker.Text,
                AddressWorker = txtAddressWorker.Text,
                PhoneWorker = txtPhoneWorker.Text,
                UserWorker = txtUserWorker.Text,
                PasswordWorker = txtPasswordWorker.Text,
                JobTitle = txtJobTitle.Text
            };
            _service.Add(worker);
            LoadData();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var worker = new Worker
            {
                IdWorker = int.Parse(txtIdWorker.Text),
                FullNameWorker = txtLastName.Text,
                IdentifyWorker = txtIdentifyWorker.Text,
                AddressWorker = txtAddressWorker.Text,
                PhoneWorker = txtPhoneWorker.Text,
                UserWorker = txtUserWorker.Text,
                PasswordWorker = txtPasswordWorker.Text,
                JobTitle = txtJobTitle.Text
            };
            _service.Update(worker);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
              int id = int.Parse(txtIdWorker.Text);
            _service.Delete(id);
            LoadData();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Si no hay nada escrito, vuelve a cargar todos los datos
                LoadData();
            }
            else
            {
                // Busca por coincidencia en LastName, UserWorker o JobTitle
                dgvWorker.DataSource = _service.Search(keyword).ToList();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            this.Close(); // vuelve al formulario padre (RecepcionistMainForm)
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart(); // reinicia la app y vuelve al login
        }

        private void dgvWorker_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvWorker.Rows[e.RowIndex];

                txtIdWorker.Text = row.Cells["IdWorker"].Value.ToString();
                txtLastName.Text = row.Cells["FullNameWorker"].Value.ToString();
                txtIdentifyWorker.Text = row.Cells["IdentifyWorker"].Value.ToString();
                txtAddressWorker.Text = row.Cells["AddressWorker"].Value.ToString();
                txtPhoneWorker.Text = row.Cells["PhoneWorker"].Value.ToString();
                txtUserWorker.Text = row.Cells["UserWorker"].Value.ToString();
                txtPasswordWorker.Text = row.Cells["PasswordWorker"].Value.ToString();
                txtJobTitle.Text = row.Cells["JobTitle"].Value.ToString();
            }

        }
        private void dgvWorker_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvWorker.Rows[e.RowIndex];

                txtIdWorker.Text = row.Cells["IdWorker"].Value.ToString();
                txtLastName.Text = row.Cells["FullNameWorker"].Value.ToString();
                txtIdentifyWorker.Text = row.Cells["IdentifyWorker"].Value.ToString();
                txtAddressWorker.Text = row.Cells["AddressWorker"].Value.ToString();
                txtPhoneWorker.Text = row.Cells["PhoneWorker"].Value.ToString();
                txtUserWorker.Text = row.Cells["UserWorker"].Value.ToString();
                txtPasswordWorker.Text = row.Cells["PasswordWorker"].Value.ToString();
                txtJobTitle.Text = row.Cells["JobTitle"].Value.ToString();
            }

        }


    }
}
