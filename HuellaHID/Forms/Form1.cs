using DPFP;
using DPFP.Capture;
using DPFP.Processing;
using HuellaHID.Forms;
using HuellaHID.Models;
using HuellaHID.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace HuellaHID.Forms
{
    public partial class Form1 : Form, DPFP.Capture.EventHandler
    {
        private Capture capturador;
        private Template templateGuardado;
        private Enrollment enroller;

        public Form1()
        {
            InitializeComponent();
            IniciarCaptura();
        }

        public void SetPacienteId(int id)
        {
            txtPacienteId.Text = id.ToString();
        }

        private void IniciarCaptura()
        {
            try
            {
                capturador = new Capture();
                if (capturador != null)
                {
                    capturador.EventHandler = this;
                    capturador.StartCapture();
                    lblEstado.Text = "Coloque el dedo en el lector...";
                }
                else
                {
                    MessageBox.Show("No se pudo iniciar el lector.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar captura: " + ex.Message);
            }
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample sample)
        {
            ProcesarMuestra(sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber) { }
        public void OnFingerTouch(object Capture, string ReaderSerialNumber) { }
        public void OnReaderConnect(object Capture, string ReaderSerialNumber) { }
        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber) { }
        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback) { }

        private void ProcesarMuestra(Sample sample)
        {
            if (enroller != null)
            {
                var features = ExtraerCaracteristicas(sample, DPFP.Processing.DataPurpose.Enrollment);
                if (features != null)
                {
                    enroller.AddFeatures(features);
                    lblEstado.Text = $"Muestras necesarias: {enroller.FeaturesNeeded}";

                    if (enroller.TemplateStatus == Enrollment.Status.Ready)
                    {
                        templateGuardado = enroller.Template;
                        lblEstado.Text = "Huella lista para enviar.";
                        btnEnviarHuella.Enabled = true;
                        enroller = null;
                    }
                }
            }
        }

        private FeatureSet ExtraerCaracteristicas(Sample sample, DPFP.Processing.DataPurpose purpose)
        {
            var extractor = new DPFP.Processing.FeatureExtraction();
            var feedback = DPFP.Capture.CaptureFeedback.None;
            var features = new FeatureSet();
            extractor.CreateFeatureSet(sample, purpose, ref feedback, ref features);
            return (feedback == DPFP.Capture.CaptureFeedback.Good) ? features : null;
        }

        private async void btnEnviarHuella_Click(object sender, EventArgs e)
        {
            int pacienteid = int.Parse(txtPacienteId.Text);
            string mano = cmbMano.Text;
            string dedo = cmbDedo.Text;

            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                templateGuardado.Serialize(ms);
                bytes = ms.ToArray();
            }

            var request = new HuellaRequest
            {
                pacienteid = pacienteid,
                mano = mano,
                dedo = dedo,
                template = Convert.ToBase64String(bytes)
            };

            btnEnviarHuella.Enabled = false;
            lblEstado.Text = "Enviando huella...";
            bool result = await ApiService.EnviarHuellaAsync(request);
            lblEstado.Text = result ? "Huella registrada correctamente" : "Error al registrar huella";
        }

        private void btnIniciarCaptura_Click(object sender, EventArgs e)
        {
            enroller = new Enrollment();
            lblEstado.Text = "Coloque el dedo varias veces hasta completar el registro.";
            btnEnviarHuella.Enabled = false;
        }
    }
}
