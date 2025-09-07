using System;

namespace AxiHotel.UI
{
    partial class RoomsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomsForm));
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.btnVerSpecs = new System.Windows.Forms.Button();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.cmbRoomStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Disponibilitytext = new System.Windows.Forms.Label();
            this.cmbHousekeeping = new System.Windows.Forms.ComboBox();
            this.btnBack = new Sunny.UI.UIButton();
            this.btnLogout = new Sunny.UI.UIButton();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRooms
            // 
            this.dgvRooms.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(197)))), ((int)(((byte)(161)))));
            this.dgvRooms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRooms.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvRooms.Location = new System.Drawing.Point(12, 79);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.Size = new System.Drawing.Size(776, 260);
            this.dgvRooms.TabIndex = 0;
            // 
            // btnVerSpecs
            // 
            this.btnVerSpecs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(104)))), ((int)(((byte)(105)))));
            this.btnVerSpecs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerSpecs.ForeColor = System.Drawing.Color.White;
            this.btnVerSpecs.Location = new System.Drawing.Point(610, 362);
            this.btnVerSpecs.Name = "btnVerSpecs";
            this.btnVerSpecs.Size = new System.Drawing.Size(130, 47);
            this.btnVerSpecs.TabIndex = 3;
            this.btnVerSpecs.Text = "Ver Especificaciones";
            this.btnVerSpecs.UseVisualStyleBackColor = false;
            this.btnVerSpecs.Click += new System.EventHandler(this.btnVerSpecs_Click);
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(104)))), ((int)(((byte)(105)))));
            this.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCambiarEstado.ForeColor = System.Drawing.Color.White;
            this.btnCambiarEstado.Location = new System.Drawing.Point(405, 362);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(126, 47);
            this.btnCambiarEstado.TabIndex = 4;
            this.btnCambiarEstado.Text = "Modificar Estado";
            this.btnCambiarEstado.UseVisualStyleBackColor = false;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // cmbRoomStatus
            // 
            this.cmbRoomStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.cmbRoomStatus.FormattingEnabled = true;
            this.cmbRoomStatus.Items.AddRange(new object[] {
            "Disponible",
            "Ocupada",
            "Mantenimiento"});
            this.cmbRoomStatus.Location = new System.Drawing.Point(80, 373);
            this.cmbRoomStatus.Name = "cmbRoomStatus";
            this.cmbRoomStatus.Size = new System.Drawing.Size(237, 27);
            this.cmbRoomStatus.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(297, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Lista de Habitaciones ";
            // 
            // Disponibilitytext
            // 
            this.Disponibilitytext.AutoSize = true;
            this.Disponibilitytext.ForeColor = System.Drawing.Color.White;
            this.Disponibilitytext.Location = new System.Drawing.Point(154, 351);
            this.Disponibilitytext.Name = "Disponibilitytext";
            this.Disponibilitytext.Size = new System.Drawing.Size(102, 19);
            this.Disponibilitytext.TabIndex = 11;
            this.Disponibilitytext.Text = "Disponibilidad ";
            this.Disponibilitytext.Click += new System.EventHandler(this.Disponibilitytext_Click);
            // 
            // cmbHousekeeping
            // 
            this.cmbHousekeeping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.cmbHousekeeping.FormattingEnabled = true;
            this.cmbHousekeeping.Items.AddRange(new object[] {
            "Limpia",
            "Sucia",
            "En limpieza"});
            this.cmbHousekeeping.Location = new System.Drawing.Point(80, 373);
            this.cmbHousekeeping.Name = "cmbHousekeeping";
            this.cmbHousekeeping.Size = new System.Drawing.Size(237, 27);
            this.cmbHousekeeping.TabIndex = 7;
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
            this.btnBack.Location = new System.Drawing.Point(12, 41);
            this.btnBack.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnBack.Name = "btnBack";
            this.btnBack.RectColor = System.Drawing.Color.Black;
            this.btnBack.RectDisableColor = System.Drawing.Color.Black;
            this.btnBack.RectHoverColor = System.Drawing.Color.Black;
            this.btnBack.RectPressColor = System.Drawing.Color.Black;
            this.btnBack.RectSelectedColor = System.Drawing.Color.Black;
            this.btnBack.Size = new System.Drawing.Size(45, 35);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "←";
            this.btnBack.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.TipsForeColor = System.Drawing.Color.Black;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
            this.btnLogout.Location = new System.Drawing.Point(674, 41);
            this.btnLogout.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RectColor = System.Drawing.Color.Black;
            this.btnLogout.RectDisableColor = System.Drawing.Color.Black;
            this.btnLogout.RectHoverColor = System.Drawing.Color.Black;
            this.btnLogout.RectPressColor = System.Drawing.Color.Black;
            this.btnLogout.RectSelectedColor = System.Drawing.Color.Black;
            this.btnLogout.Size = new System.Drawing.Size(114, 35);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Cerrar Sesión";
            this.btnLogout.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.TipsForeColor = System.Drawing.Color.Black;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(122, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Estado de la Habitación";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // RoomsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Disponibilitytext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbHousekeeping);
            this.Controls.Add(this.cmbRoomStatus);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.btnVerSpecs);
            this.Controls.Add(this.dgvRooms);
            this.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoomsForm";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.Text = "Habitaciones";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.TitleFont = new System.Drawing.Font("Poor Richard", 12F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.RoomsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.Button btnVerSpecs;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox cmbRoomStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Disponibilitytext;
        private System.Windows.Forms.ComboBox cmbHousekeeping;
        private Sunny.UI.UIButton btnBack;
        private Sunny.UI.UIButton btnLogout;
        private System.Windows.Forms.Label label4;
    }
}