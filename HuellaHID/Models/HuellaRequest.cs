namespace HuellaHID.Models
{
    public class HuellaRequest
    {
        public int pacienteid { get; set; }
        public string mano { get; set; }
        public string dedo { get; set; }
        public string template { get; set; } // base64
    }
}
