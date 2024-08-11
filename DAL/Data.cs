using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class Data:DbContext
    {
        public Data(DbContextOptions<Data>options):base(options)
        {

        }
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Skladiste> StanjeSkladista { get; set; }
        public DbSet<Prilagodba> Prilagodbe { get; set; }
        public DbSet<Stavka> Stavka { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Normativi>Normativi { get; set; }
    }
}
