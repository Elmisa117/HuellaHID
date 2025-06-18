using System;
using System.Drawing;
using System.Windows.Forms;

namespace HuellaHID.Forms
{
    // Ventana principal con opciones de registro y búsqueda
    public class MainForm : Form
    {
        private Button btnRegistrar;
        private Button btnBuscar;

        public MainForm()
        {
            Text = "Huella HID";
            Width = 250;
            Height = 150;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.AliceBlue;
            Font = new Font("Segoe UI", 9F);

            btnRegistrar = new Button
            {
                Text = "Registrar Paciente",
                Left = 30,
                Top = 20,
                Width = 180,
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
            };
            btnRegistrar.FlatAppearance.BorderSize = 0;

            btnBuscar = new Button
            {
                Text = "Buscar Paciente",
                Left = 30,
                Top = 60,
                Width = 180,
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
            };
            btnBuscar.FlatAppearance.BorderSize = 0;

            btnRegistrar.Click += (s, e) =>
            {
                using (var f = new Form1())
                {
                    f.ShowDialog();
                }
            };

            btnBuscar.Click += (s, e) =>
            {
                using (var f = new BuscarForm())
                {
                    f.ShowDialog();
                }
            };

            Controls.Add(btnRegistrar);
            Controls.Add(btnBuscar);
        }
    }
}
