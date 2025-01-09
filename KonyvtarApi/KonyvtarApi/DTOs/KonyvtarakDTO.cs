using KonyvtarApi.Models;

namespace KonyvtarApi.DTOs
{
    public class KonyvtarakDTO
    {
        public int Id { get; set; }

        public string KonyvtarNev { get; set; } = null!;

        public int Irsz { get; set; }

        public string Cim { get; set; } = null!;

        public string TelepulesNev { get; set; } = null!; 

        public string MegyeNev { get; set; } = null!;
    }
}
