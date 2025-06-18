namespace HuellaHID.Forms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtPacienteId = new System.Windows.Forms.TextBox();
            this.cmbMano = new System.Windows.Forms.ComboBox();
            this.cmbDedo = new System.Windows.Forms.ComboBox();
            this.btnIniciarCaptura = new System.Windows.Forms.Button();
            this.btnEnviarHuella = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblPacienteId = new System.Windows.Forms.Label();
            this.lblMano = new System.Windows.Forms.Label();
            this.lblDedo = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // lblPacienteId
            this.lblPacienteId.AutoSize = true;
            this.lblPacienteId.Location = new System.Drawing.Point(30, 30);
            this.lblPacienteId.Name = "lblPacienteId";
            this.lblPacienteId.Size = new System.Drawing.Size(64, 13);
            this.lblPacienteId.Text = "Paciente ID:";

            // txtPacienteId
            this.txtPacienteId.Location = new System.Drawing.Point(120, 27);
            this.txtPacienteId.Name = "txtPacienteId";
            this.txtPacienteId.Size = new System.Drawing.Size(150, 20);

            // lblMano
            this.lblMano.AutoSize = true;
            this.lblMano.Location = new System.Drawing.Point(30, 65);
            this.lblMano.Name = "lblMano";
            this.lblMano.Size = new System.Drawing.Size(37, 13);
            this.lblMano.Text = "Mano:";

            // cmbMano
            this.cmbMano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMano.Items.AddRange(new object[] { "Derecha", "Izquierda" });
            this.cmbMano.Location = new System.Drawing.Point(120, 62);
            this.cmbMano.Name = "cmbMano";
            this.cmbMano.Size = new System.Drawing.Size(150, 21);

            // lblDedo
            this.lblDedo.AutoSize = true;
            this.lblDedo.Location = new System.Drawing.Point(30, 100);
            this.lblDedo.Name = "lblDedo";
            this.lblDedo.Size = new System.Drawing.Size(36, 13);
            this.lblDedo.Text = "Dedo:";

            // cmbDedo
            this.cmbDedo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDedo.Items.AddRange(new object[] { "Pulgar", "Índice", "Medio", "Anular", "Meñique" });
            this.cmbDedo.Location = new System.Drawing.Point(120, 97);
            this.cmbDedo.Name = "cmbDedo";
            this.cmbDedo.Size = new System.Drawing.Size(150, 21);

            // btnIniciarCaptura
            this.btnIniciarCaptura.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnIniciarCaptura.FlatAppearance.BorderSize = 0;
            this.btnIniciarCaptura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarCaptura.ForeColor = System.Drawing.Color.White;
            this.btnIniciarCaptura.Location = new System.Drawing.Point(30, 140);
            this.btnIniciarCaptura.Name = "btnIniciarCaptura";
            this.btnIniciarCaptura.Size = new System.Drawing.Size(240, 30);
            this.btnIniciarCaptura.Text = "Iniciar Captura de Huella";
            this.btnIniciarCaptura.UseVisualStyleBackColor = false;
            this.btnIniciarCaptura.Click += new System.EventHandler(this.btnIniciarCaptura_Click);

            // btnEnviarHuella
            this.btnEnviarHuella.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEnviarHuella.FlatAppearance.BorderSize = 0;
            this.btnEnviarHuella.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarHuella.ForeColor = System.Drawing.Color.White;
            this.btnEnviarHuella.Location = new System.Drawing.Point(30, 180);
            this.btnEnviarHuella.Name = "btnEnviarHuella";
            this.btnEnviarHuella.Size = new System.Drawing.Size(240, 30);
            this.btnEnviarHuella.Text = "Enviar Huella";
            this.btnEnviarHuella.UseVisualStyleBackColor = false;
            this.btnEnviarHuella.Enabled = false;
            this.btnEnviarHuella.Click += new System.EventHandler(this.btnEnviarHuella_Click);

            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.Navy;
            this.lblEstado.Location = new System.Drawing.Point(30, 220);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(120, 13);
            this.lblEstado.Text = "Estado del lector huella.";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(300, 260);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Controls.Add(this.lblPacienteId);
            this.Controls.Add(this.txtPacienteId);
            this.Controls.Add(this.lblMano);
            this.Controls.Add(this.cmbMano);
            this.Controls.Add(this.lblDedo);
            this.Controls.Add(this.cmbDedo);
            this.Controls.Add(this.btnIniciarCaptura);
            this.Controls.Add(this.btnEnviarHuella);
            this.Controls.Add(this.lblEstado);
            this.Name = "Form1";
            this.Text = "Registro de Huella";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtPacienteId;
        private System.Windows.Forms.ComboBox cmbMano;
        private System.Windows.Forms.ComboBox cmbDedo;
        private System.Windows.Forms.Button btnIniciarCaptura;
        private System.Windows.Forms.Button btnEnviarHuella;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblPacienteId;
        private System.Windows.Forms.Label lblMano;
        private System.Windows.Forms.Label lblDedo;
    }
}
