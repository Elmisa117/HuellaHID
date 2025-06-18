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

                // Mostrar el JSON que se envía (para debug)
                MessageBox.Show("📤 Enviando JSON:\n" + json);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                var respStr = await response.Content.ReadAsStringAsync();

                // Mostrar código de estado y respuesta completa
                MessageBox.Show($"🔍 Status: {(int)response.StatusCode}\nRespuesta:\n{respStr}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("✅ Huella registrada correctamente.");
                    return true;
                }
                else
                {
                    MessageBox.Show($"❌ Error al registrar huella ({(int)response.StatusCode}).");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error de red: " + ex.Message);
                return false;
            }
        }
    }
}
