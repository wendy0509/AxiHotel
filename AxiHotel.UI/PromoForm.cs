using AxiHotel.Business;
using AxiHotel.Business.Services;
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
using System.Xml.Linq;
using static Sunny.UI.SnowFlakeId;

namespace AxiHotel.UI
{
    public partial class Promociones : UIForm
    {
        private readonly PromotionService _srv = new PromotionService();

        public Promociones()
        {
            InitializeComponent();
            this.Load += PromoForm_Load;

            // 🔹 Botones de agregar/eliminar visibles solo para admin
            if (SessionManager.CurrentWorker.JobTitle == "Administrador")
            {
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                txtId.Visible = true;
                txtDesc.Visible = true;
                dtpinicio.Visible = true;
                dtpfin.Visible = true;
                txtName.Visible = true;
                txtWorker.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
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
                dtpinicio.Visible = false;
                dtpfin.Visible = false;
                txtName.Visible = false;
                txtWorker.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }
        }

        private void PromoForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvPromociones.DataSource = _srv.GetAll().ToList();
            dgvPromociones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPromociones.ClearSelection(); // no dejar seleccionada ninguna fila
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart(); // reinicia la app y vuelve al login
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // vuelve al formulario padre
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("⚠️ Selecciona una promoción para eliminar.");
                    return;
                }

                var id = int.Parse(txtId.Text);
                _srv.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al eliminar: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("⚠️ Debes seleccionar una promoción para actualizar.");
                    return;
                }

                var promotion = new Promotions
                {
                    IdPromotion = int.Parse(txtId.Text),
                    DateStartPromotions = dtpinicio.Value,
                    DateEndPromotions = dtpfin.Value,
                    DescriptionPromotions = txtDesc.Text,
                    NamePromotions = txtName.Text,
                    IdWorker = int.Parse(txtWorker.Text)
                };

                _srv.Update(promotion);

                MessageBox.Show("✅ Promoción actualizada correctamente.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al actualizar: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var promotion = new Promotions
                {
                    DateStartPromotions = dtpinicio.Value,
                    DateEndPromotions = dtpfin.Value,
                    DescriptionPromotions = txtDesc.Text,
                    NamePromotions = txtName.Text,
                    IdWorker = int.Parse(txtWorker.Text)
                };

                _srv.Add(promotion);

                MessageBox.Show("✅ Promoción registrada correctamente.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al registrar: {ex.Message}");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvPromociones.DataSource = _srv.Search(txtBuscar.Text).ToList();
        }

        // 🔹 Cargar datos de la fila seleccionada en los TextBox
        private void dgvPromociones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvPromociones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // asegurarse que no es cabecera
            {
                var row = dgvPromociones.Rows[e.RowIndex];

                txtId.Text = row.Cells["IdPromotion"].Value.ToString();
                txtDesc.Text = row.Cells["DescriptionPromotions"].Value.ToString();
                txtName.Text = row.Cells["NamePromotions"].Value.ToString();
                txtWorker.Text = row.Cells["IdWorker"].Value.ToString();

                dtpinicio.Value = Convert.ToDateTime(row.Cells["DateStartPromotions"].Value);
                dtpfin.Value = Convert.ToDateTime(row.Cells["DateEndPromotions"].Value);
            }
        }
    }

}
