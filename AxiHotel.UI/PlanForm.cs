using AxiHotel.Business;
using AxiHotel.Data.Models;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AxiHotel.UI
{
    public partial class PlanForm : UIForm
    {
        private readonly PlanService _srv = new PlanService();
        public PlanForm()
        {
            InitializeComponent();
            this.Load += PlanForm_Load;
            // 🔹 Botones de agregar/eliminar visibles solo para admin
            if (SessionManager.CurrentWorker.JobTitle == "Administrador")
            {
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                txtId.Visible = true;
                txtDesc.Visible = true;
                nudPersonas.Visible = true;
                txtname.Visible = true;
                txtWorker.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                txtId.Visible = false;
                txtDesc.Visible = false;
                nudPersonas.Visible = false;
                txtname.Visible = false;
                txtWorker.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }
        
        }
        private void PlanForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dgvPlan.DataSource = _srv.GetAll().ToList();
            dgvPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            Application.Restart(); // reinicia la app y vuelve al login
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var plan = new HotelPlan
                {
                    HowManyPeoplePlan = int.Parse(nudPersonas.Text),
                    DescriptionPlan = txtDesc.Text,
                    NamePlan = txtname.Text,
                    IdWorker = int.Parse(txtWorker.Text)
                };

                _srv.Add(plan);
                MessageBox.Show("✅ Plan registrado correctamente.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al registrar el plan: {ex.Message}");
            }
        }
        private void dgvPlanes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Validar que sea una fila válida
            {
                DataGridViewRow row = dgvPlan.Rows[e.RowIndex];

                // Llenar los campos con la fila seleccionada
                txtId.Text = row.Cells["IdPlan"].Value.ToString();
                txtname.Text = row.Cells["NamePlan"].Value.ToString();
                txtDesc.Text = row.Cells["DescriptionPlan"].Value.ToString();
                nudPersonas.Text = row.Cells["HowManyPeoplePlan"].Value.ToString();
                txtWorker.Text = row.Cells["IdWorker"].Value.ToString();
            }
        }
        private void dgvPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Validar que sea una fila válida
            {
                DataGridViewRow row = dgvPlan.Rows[e.RowIndex];

                // Llenar los campos con la fila seleccionada
                txtId.Text = row.Cells["IdPlan"].Value.ToString();
                txtname.Text = row.Cells["NamePlan"].Value.ToString();
                txtDesc.Text = row.Cells["DescriptionPlan"].Value.ToString();
                nudPersonas.Text = row.Cells["HowManyPeoplePlan"].Value.ToString();
                txtWorker.Text = row.Cells["IdWorker"].Value.ToString();
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvPlan.DataSource = _srv.Search(txtBuscar.Text).ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("⚠️ Debes seleccionar un plan para actualizar.");
                    return;
                }

                var plan = new HotelPlan
                {
                    IdPlan = int.Parse(txtId.Text),
                    HowManyPeoplePlan = int.Parse(nudPersonas.Text),
                    DescriptionPlan = txtDesc.Text,
                    NamePlan = txtname.Text,
                    IdWorker = int.Parse(txtWorker.Text)
                };

                _srv.Update(plan);
                MessageBox.Show("✅ Plan actualizado correctamente.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al actualizar el plan: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(txtId.Text);
                _srv.Delete(id);
                MessageBox.Show("✅ Plan eliminado correctamente.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al eliminar el plan: {ex.Message}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // vuelve al formulario padre
        }

  
    }
}
