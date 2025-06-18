namespace HuellaHID.Models
{
    // Representa una huella almacenada en la base de datos
    public class PatientFingerprint
    {
        public int PacienteId { get; set; }
        public string Nombre { get; set; }
        public string Mano { get; set; }
        public string Dedo { get; set; }
        public byte[] TemplateBytes { get; set; }
    }
}
