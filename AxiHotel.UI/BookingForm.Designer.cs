namespace AxiHotel.UI
{
    partial class BookingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingForm));
            this.btnLogout = new Sunny.UI.UIButton();
            this.btnBack = new Sunny.UI.UIButton();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.txtIdBooking = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtClienteId = new System.Windows.Forms.TextBox();
            this.txtPromoId = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtHabitacionId = new System.Windows.Forms.TextBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.nudPersonas = new System.Windows.Forms.NumericUpDown();
            this.cboEstado = new Sunny.UI.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPlanId = new System.Windows.Forms.TextBox();
            this.txtIdWorker = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(197)))), ((int)(((byte)(161)))));
            this.btnLogout.FillColor2 = System.Drawing.Color.Black;
            this.btnLogout.FillHoverColor = System.Drawing.Color.Black;
            this.btnLogout.FillPressColor = System.Drawing.Color.Black;
            this.btnLogout.FillSelectedColor = System.Drawing.Color.Black;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(683, 38);
            this.btnLogout.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RectColor = System.Drawing.Color.Black;
            this.btnLogout.RectDisableColor = System.Drawing.Color.Black;
            this.btnLogout.RectHoverColor = System.Drawing.Color.Black;
            this.btnLogout.RectPressColor = System.Drawing.Color.Black;
            this.btnLogout.RectSelectedColor = System.Drawing.Color.Black;
            this.btnLogout.Size = new System.Drawing.Size(114, 35);
            this.btnLogout.TabIndex = 17;
            this.btnLogout.Text = "Cerrar Sesión";
            this.btnLogout.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.TipsForeColor = System.Drawing.Color.Black;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(197)))), ((int)(((byte)(161)))));
            this.btnBack.FillColor2 = System.Drawing.Color.Black;
            this.btnBack.FillHoverColor = System.Drawing.Color.Black;
            this.btnBack.FillPressColor = System.Drawing.Color.Black;
            this.btnBack.FillSelectedColor = System.Drawing.Color.Black;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(3, 38);
            this.btnBack.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnBack.Name = "btnBack";
            this.btnBack.RectColor = System.Drawing.Color.Black;
            this.btnBack.RectDisableColor = System.Drawing.Color.Black;
            this.btnBack.RectHoverColor = System.Drawing.Color.Black;
            this.btnBack.RectPressColor = System.Drawing.Color.Black;
            this.btnBack.RectSelectedColor = System.Drawing.Color.Black;
            this.btnBack.Size = new System.Drawing.Size(45, 35);
            this.btnBack.TabIndex = 18;
            this.btnBack.Text = "←";
            this.btnBack.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.TipsForeColor = System.Drawing.Color.Black;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvBookings
            // 
            this.dgvBookings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(197)))), ((int)(((byte)(161)))));
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(3, 79);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.Size = new System.Drawing.Size(794, 281);
            this.dgvBookings.TabIndex = 19;
            this.dgvBookings.SelectionChanged += new System.EventHandler(this.DgvBookings_SelectionChanged);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(104)))), ((int)(((byte)(105)))));
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrar.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.btnRegistrar.Location = new System.Drawing.Point(263, 615);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(111, 48);
            this.btnRegistrar.TabIndex = 20;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(104)))), ((int)(((byte)(105)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.btnEditar.Location = new System.Drawing.Point(420, 615);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(111, 48);
            this.btnEditar.TabIndex = 21;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // txtIdBooking
            // 
            this.txtIdBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtIdBooking.Location = new System.Drawing.Point(28, 396);
            this.txtIdBooking.Name = "txtIdBooking";
            this.txtIdBooking.Size = new System.Drawing.Size(170, 26);
            this.txtIdBooking.TabIndex = 22;
            this.txtIdBooking.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtPrecio.Location = new System.Drawing.Point(318, 393);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(174, 26);
            this.txtPrecio.TabIndex = 24;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClienteId
            // 
            this.txtClienteId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtClienteId.Location = new System.Drawing.Point(318, 448);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.Size = new System.Drawing.Size(174, 26);
            this.txtClienteId.TabIndex = 25;
            this.txtClienteId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPromoId
            // 
            this.txtPromoId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtPromoId.Location = new System.Drawing.Point(593, 393);
            this.txtPromoId.Name = "txtPromoId";
            this.txtPromoId.Size = new System.Drawing.Size(174, 26);
            this.txtPromoId.TabIndex = 26;
            this.txtPromoId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtDescripcion.Location = new System.Drawing.Point(28, 504);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(170, 26);
            this.txtDescripcion.TabIndex = 28;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHabitacionId
            // 
            this.txtHabitacionId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtHabitacionId.Location = new System.Drawing.Point(318, 504);
            this.txtHabitacionId.Name = "txtHabitacionId";
            this.txtHabitacionId.Size = new System.Drawing.Size(174, 26);
            this.txtHabitacionId.TabIndex = 29;
            this.txtHabitacionId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(28, 566);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(170, 26);
            this.dtpInicio.TabIndex = 31;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(318, 566);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(174, 26);
            this.dtpFin.TabIndex = 32;
            // 
            // nudPersonas
            // 
            this.nudPersonas.Location = new System.Drawing.Point(161, 448);
            this.nudPersonas.Name = "nudPersonas";
            this.nudPersonas.Size = new System.Drawing.Size(37, 26);
            this.nudPersonas.TabIndex = 33;
            // 
            // cboEstado
            // 
            this.cboEstado.DataSource = null;
            this.cboEstado.FillColor = System.Drawing.Color.White;
            this.cboEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboEstado.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cboEstado.Items.AddRange(new object[] {
            "Pagado",
            "Pendiente"});
            this.cboEstado.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cboEstado.Location = new System.Drawing.Point(593, 504);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboEstado.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboEstado.Size = new System.Drawing.Size(174, 23);
            this.cboEstado.SymbolSize = 24;
            this.cboEstado.TabIndex = 34;
            this.cboEstado.Text = "uiComboBox1";
            this.cboEstado.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cboEstado.Watermark = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 35;
            this.label2.Text = "Id Reserva";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 19);
            this.label1.TabIndex = 36;
            this.label1.Text = "Numero de Personas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 482);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 37;
            this.label3.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
            this.label4.TabIndex = 38;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 426);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 19);
            this.label5.TabIndex = 39;
            this.label5.Text = "Id Cliente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 482);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 40;
            this.label6.Text = "Id Habitación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(630, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 19);
            this.label7.TabIndex = 41;
            this.label7.Text = "Id Promoción";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(646, 426);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 19);
            this.label8.TabIndex = 42;
            this.label8.Text = "Id Plan";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(648, 482);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 43;
            this.label9.Text = "Estado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 544);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 19);
            this.label10.TabIndex = 44;
            this.label10.Text = "Fecha de Ingreso";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(361, 544);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 19);
            this.label11.TabIndex = 45;
            this.label11.Text = "Fecha de Salida";
            // 
            // txtPlanId
            // 
            this.txtPlanId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtPlanId.Location = new System.Drawing.Point(593, 448);
            this.txtPlanId.Name = "txtPlanId";
            this.txtPlanId.Size = new System.Drawing.Size(174, 26);
            this.txtPlanId.TabIndex = 30;
            this.txtPlanId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIdWorker
            // 
            this.txtIdWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtIdWorker.Location = new System.Drawing.Point(593, 566);
            this.txtIdWorker.Name = "txtIdWorker";
            this.txtIdWorker.Size = new System.Drawing.Size(174, 26);
            this.txtIdWorker.TabIndex = 46;
            this.txtIdWorker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(630, 544);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 19);
            this.label12.TabIndex = 47;
            this.label12.Text = "Recepcionista";
            // 
            // BookingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(800, 666);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtIdWorker);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.nudPersonas);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.txtPlanId);
            this.Controls.Add(this.txtHabitacionId);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtPromoId);
            this.Controls.Add(this.txtClienteId);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtIdBooking);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLogout);
            this.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BookingForm";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.Text = "BookingForm";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIButton btnLogout;
        private Sunny.UI.UIButton btnBack;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtIdBooking;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtClienteId;
        private System.Windows.Forms.TextBox txtPromoId;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtHabitacionId;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.NumericUpDown nudPersonas;
        private Sunny.UI.UIComboBox cboEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPlanId;
        private System.Windows.Forms.TextBox txtIdWorker;
        private System.Windows.Forms.Label label12;
    }
}