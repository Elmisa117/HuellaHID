using HuellaHID.Forms;
using System;
using System.Windows.Forms;

namespace HuellaHID.Forms
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0 && int.TryParse(args[0], out int pacienteId))
            {
                var form = new Form1();
                form.SetPacienteId(pacienteId);
                Application.Run(form);
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
