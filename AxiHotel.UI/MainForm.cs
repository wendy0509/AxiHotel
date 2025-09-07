using AxiHotel.Business;
using System;
using System.Windows.Forms;

namespace AxiHotel.UI
{
    public partial class MainForm : Form
    {
        private readonly WorkerService _service;
        public MainForm()
        {
            InitializeComponent();
            _service = new WorkerService();
        }

      //  private void btnload_Click(object sender, EventArgs e)
        //{
          //  dgvWorkers.DataSource = _service.GetWorkers();
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
