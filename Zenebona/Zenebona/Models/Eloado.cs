namespace Zenebona.Models
{
    public class Eloado
    {
        public int Id { get; set; }
        public string? Nev { get; set; }
        public string? Nemzetiseg { get; set; }
        public bool Elo {  get; set; }
        public virtual ICollection<Zeneszam> Zeneszamok {  get; set; } = new List<Zeneszam>();
    }
}
