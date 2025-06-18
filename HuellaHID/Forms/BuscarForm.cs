using DPFP;
using DPFP.Capture;
using DPFP.Processing;
using HuellaHID.Models;
using HuellaHID.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HuellaHID.Forms
{
    // Formulario para capturar una huella y buscar al paciente en la base de datos
    public class BuscarForm : Form, DPFP.Capture.EventHandler
    {
        private Label lblInfo;
        private Capture capturador;
        private Verification verificator;
        private List<PatientFingerprint> huellas;

        public BuscarForm()
        {
            Text = "Buscar Paciente";
            Width = 300;
            Height = 120;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.AliceBlue;
            Font = new Font("Segoe UI", 9F);
            lblInfo = new Label
            {
                Text = "Coloque su huella para buscar",
                AutoSize = true,
                Left = 20,
                Top = 20,
                ForeColor = Color.Navy
            };
            Controls.Add(lblInfo);

            Load += async (s, e) => await InicializarAsync();
        }

        private async Task InicializarAsync()
        {
            huellas = await DatabaseService.ObtenerHuellasAsync();
            verificator = new Verification();

            capturador = new Capture();
            if (capturador != null)
            {
                capturador.EventHandler = this;
                capturador.StartCapture();
            }
            else
            {
                MessageBox.Show("No se pudo iniciar el lector");
            }
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample sample)
        {
            var features = ExtraerCaracteristicas(sample, DataPurpose.Verification);
            if (features == null) return;

            foreach (var h in huellas)
            {
                var template = new Template();
                using (var ms = new MemoryStream(h.TemplateBytes))
                {
                    template.Deserialize(ms);
                }
                var result = new Verification.Result();
                verificator.Verify(features, template, ref result);
                if (result.Verified)
                {
                    capturador.StopCapture();
                    BeginInvoke(new Action(async () =>
                    {
                        lblInfo.Text = $"Paciente encontrado: {h.Nombre} (ID: {h.PacienteId})";
                        await ApiService.EnviarResultadoAsync(h.PacienteId);
                    }));
                    return;
                }
            }

            BeginInvoke(new Action(() => { lblInfo.Text = "Paciente no encontrado"; }));
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber) { }
        public void OnFingerTouch(object Capture, string ReaderSerialNumber) { }
        public void OnReaderConnect(object Capture, string ReaderSerialNumber) { }
        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber) { }
        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback) { }

        private FeatureSet ExtraerCaracteristicas(Sample sample, DataPurpose purpose)
        {
            var extractor = new FeatureExtraction();
            var feedback = CaptureFeedback.None;
            var features = new FeatureSet();
            extractor.CreateFeatureSet(sample, purpose, ref feedback, ref features);
            return feedback == CaptureFeedback.Good ? features : null;
        }
    }
}
