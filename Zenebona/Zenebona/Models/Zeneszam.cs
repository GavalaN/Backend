namespace Zenebona.Models
{
    public class Zeneszam
    {
        public int Id { get; set; }
        public string? Nev { get; set; }
        public int MegjelenesEve { get; set; }
        public double LejatszasiIdo { get; set; }
        public bool Jogdijas { get; set; }
        public int EloadoId { get; set; }
        public int KiadoId { get; set; }
        public virtual Eloado? Eloado {get; set;}
        public virtual Kiado? Kiado { get; set; }
    }
}
