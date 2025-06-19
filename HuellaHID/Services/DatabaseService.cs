using HuellaHID.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuellaHID.Services
{
    // Servicio para guardar y obtener huellas desde PostgreSQL
    public static class DatabaseService
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

        public static async Task<bool> GuardarHuellaAsync(int pacienteId, string mano, string dedo, byte[] templateBytes)
        {
            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                await conn.OpenAsync();
                // La tabla real en la base es 'huellasdactilares'
                using var cmd = new NpgsqlCommand("INSERT INTO huellasdactilares(paciente_id, mano, dedo, template) VALUES (@p1,@p2,@p3,@p4)", conn);
                cmd.Parameters.AddWithValue("@p1", pacienteId);
                cmd.Parameters.AddWithValue("@p2", mano);
                cmd.Parameters.AddWithValue("@p3", dedo);
                cmd.Parameters.AddWithValue("@p4", templateBytes);
                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message);
                return false;
            }
        }

        public static async Task<List<PatientFingerprint>> ObtenerHuellasAsync()
        {
            var list = new List<PatientFingerprint>();
            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                await conn.OpenAsync();
                // Leemos desde la tabla 'huellasdactilares'
                using var cmd = new NpgsqlCommand("SELECT h.paciente_id, p.nombre, h.mano, h.dedo, h.template FROM huellasdactilares h JOIN pacientes p ON p.id = h.paciente_id", conn);
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    list.Add(new PatientFingerprint
                    {
                        PacienteId = reader.GetInt32(0),
                        Nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Mano = reader.GetString(2),
                        Dedo = reader.GetString(3),
                        TemplateBytes = (byte[])reader[4]
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener huellas: " + ex.Message);
            }
            return list;
        }
    }
}
