using HuellaHID.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuellaHID.Services
{
    public static class ApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<bool> EnviarHuellaAsync(HuellaRequest data)
        {
            try
            {
                string url = "http://127.0.0.1:8000/admin/api/registrar-huella/";
                var json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Servidor no disponible: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar huella: " + ex.Message);
                return false;
            }
        }

        // Envía el paciente encontrado al backend
        public static async Task<bool> EnviarResultadoAsync(int pacienteId)
        {
            try
            {
                string url = "http://localhost:8000/api/biometrico/resultado/";
                var obj = new ResultadoRequest { paciente_id = pacienteId };
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Servidor no disponible: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando resultado: " + ex.Message);
                return false;
            }
        }
    }
}
