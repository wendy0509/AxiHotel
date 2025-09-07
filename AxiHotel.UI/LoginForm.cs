using AxiHotel.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace AxiHotel.UI
{
    public partial class LoginForm : UIForm
    {
        private readonly WorkerService _service;

        public LoginForm()
        {
            InitializeComponent();
            _service = new WorkerService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPassword.Text;

            try
            {
                var worker = _service.Authenticate(user, pass);
                if (worker == null)
                {
                    MessageBox.Show("Usuario o contraseña inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar sesión
                SessionManager.CurrentWorker = worker;

                // Indica al Program.cs que la autenticación fue exitosa
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar autenticar: " + ex.Message);
            }
        }


    }
}
