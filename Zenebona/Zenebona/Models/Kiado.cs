namespace Zenebona.Models
{
    public class Kiado
    {
        public int Id { get; set; }
        public string? Nev { get; set; }
        public short AlapitasEve { get; set; }
        public string? Cim { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<Zeneszam> Zeneszamok { get; set; } = new List<Zeneszam>();
    }
}
