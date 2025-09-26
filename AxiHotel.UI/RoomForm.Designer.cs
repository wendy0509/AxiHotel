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
            this.Disponibilitytext = new System.Windows.Forms.Label();
            this.cmbHousekeeping = new System.Windows.Forms.ComboBox();
            this.btnBack = new Sunny.UI.UIButton();
            this.btnLogout = new Sunny.UI.UIButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtHouse = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.dgvRooms.Location = new System.Drawing.Point(12, 82);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.Size = new System.Drawing.Size(776, 247);
            this.dgvRooms.TabIndex = 0;
            // 
            // btnVerSpecs
            // 
            this.btnVerSpecs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(104)))), ((int)(((byte)(105)))));
            this.btnVerSpecs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerSpecs.ForeColor = System.Drawing.Color.White;
            this.btnVerSpecs.Location = new System.Drawing.Point(398, 386);
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
            this.btnCambiarEstado.Location = new System.Drawing.Point(266, 386);
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
            this.cmbRoomStatus.Location = new System.Drawing.Point(12, 406);
            this.cmbRoomStatus.Name = "cmbRoomStatus";
            this.cmbRoomStatus.Size = new System.Drawing.Size(237, 27);
            this.cmbRoomStatus.TabIndex = 6;
            // 
            // Disponibilitytext
            // 
            this.Disponibilitytext.AutoSize = true;
            this.Disponibilitytext.ForeColor = System.Drawing.Color.White;
            this.Disponibilitytext.Location = new System.Drawing.Point(76, 376);
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
            this.cmbHousekeeping.Location = new System.Drawing.Point(12, 406);
            this.cmbHousekeeping.Name = "cmbHousekeeping";
            this.cmbHousekeeping.Size = new System.Drawing.Size(237, 27);
            this.cmbHousekeeping.TabIndex = 7;
            this.cmbHousekeeping.SelectedIndexChanged += new System.EventHandler(this.cmbHousekeeping_SelectedIndexChanged);
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
            this.label4.Location = new System.Drawing.Point(54, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Estado de la Habitación";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(104)))), ((int)(((byte)(105)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(534, 386);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 47);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Añadir Habitación\r\n\r\n";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(104)))), ((int)(((byte)(105)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(667, 386);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 47);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Eliminar Habitación\r\n";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtBuscar.Location = new System.Drawing.Point(332, 47);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(226, 26);
            this.txtBuscar.TabIndex = 18;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Buscar";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtDescription.Location = new System.Drawing.Point(29, 407);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(126, 26);
            this.txtDescription.TabIndex = 20;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtStatus.Location = new System.Drawing.Point(232, 406);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(126, 26);
            this.txtStatus.TabIndex = 21;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHouse
            // 
            this.txtHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtHouse.Location = new System.Drawing.Point(29, 357);
            this.txtHouse.Name = "txtHouse";
            this.txtHouse.Size = new System.Drawing.Size(126, 26);
            this.txtHouse.TabIndex = 22;
            this.txtHouse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtType
            // 
            this.txtType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtType.Location = new System.Drawing.Point(232, 357);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(126, 26);
            this.txtType.TabIndex = 23;
            this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "Estado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 19);
            this.label5.TabIndex = 26;
            this.label5.Text = "Estado de limpieza";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 19);
            this.label6.TabIndex = 27;
            this.label6.Text = "Tipo de Habitación";
            // 
            // RoomsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtHouse);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Disponibilitytext);
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
        private System.Windows.Forms.Label Disponibilitytext;
        private System.Windows.Forms.ComboBox cmbHousekeeping;
        private Sunny.UI.UIButton btnBack;
        private Sunny.UI.UIButton btnLogout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtHouse;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}