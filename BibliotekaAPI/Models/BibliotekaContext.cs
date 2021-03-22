using Microsoft.EntityFrameworkCore;

namespace BibliotekaAPI.Models
{
    public class BibliotekaContext:DbContext{

        public DbSet<Biblioteka> Biblioteke { get; set; }
        public DbSet<Polica> Police { get; set; }
        public DbSet<Knjiga> Knjige { get; set; }
        public BibliotekaContext(DbContextOptions o): base(o){

        }

    }

}