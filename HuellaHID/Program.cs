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

            var form = new Form1();

            if (args.Length > 0 && int.TryParse(args[0], out int pacienteId))
            {
                form.SetPacienteId(pacienteId);
            }

            Application.Run(form);
        }
    }
}
