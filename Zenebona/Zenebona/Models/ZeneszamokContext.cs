using Microsoft.EntityFrameworkCore;

namespace Zenebona.Models
{
    public class ZeneszamokContext : DbContext
    {
        public ZeneszamokContext() { }

        public ZeneszamokContext(DbContextOptions<ZeneszamokContext> options) : base(options) { }
    
        public virtual DbSet<Zeneszam> Zeneszamok {  get; set; }

        public virtual DbSet<Kiado> Kiadok { get; set; }

        public virtual DbSet<Eloado> Eloadok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=zeneszamok;USER=root;PASSWORD=;SSL MODE=none;");
    }
}
