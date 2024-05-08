using BLL.Interface;
using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ArtikalRepo : IArtikal
    {
        private readonly Data _dbContext;

        public ArtikalRepo(Data dbContext)
        {
            _dbContext = dbContext;
        }

        public Artikal CreateArtikal(Artikal artikal)
        {
            _dbContext.Artikli.Add(artikal);
            _dbContext.SaveChanges();
            return artikal;
        }

        public ICollection<Artikal> GetAllArtikal()
        {
            return _dbContext.Artikli.ToList();
        }

        public void DeleteArtikal(int id)
        {
            var artikal = _dbContext.Artikli.Find(id);
            if (artikal != null)
            {
                _dbContext.Artikli.Remove(artikal);
                _dbContext.SaveChanges();
            }
        }

        public Artikal GetArtikaldId(int id)
        {
            return _dbContext.Artikli.Find(id);
        }

        public void UpdateArtikal(int id, Artikal artikal)
        {
            var existingArtikal = _dbContext.Artikli.Find(id);
            if (existingArtikal != null)
            {
                existingArtikal.Naziv = artikal.Naziv;
                existingArtikal.Cijena = artikal.Cijena;
                existingArtikal.Kategorija_Id = artikal.Kategorija_Id;
                existingArtikal.Kolicina = artikal.Kolicina;
                _dbContext.SaveChanges();
            }
        }
    }
}
