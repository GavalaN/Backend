namespace Olimpikonok.DTOs
{
    public class SportoloDTO
    {
        public int Id { get; set; }

        public string Nev { get; set; } = null!;

        public bool Neme { get; set; }

        public DateTime Szuldatum { get; set; }

        public string SportagNev { get; set; }

        public int Ermek { get; set; }

        public string OrszagNev { get; set; }

        public byte[] IndexKep { get; set; } = null!;
    }
}
