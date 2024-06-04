using System;
using BLL.Interface;
using BLL.Models;

namespace DAL.Repositories
{
	public class KategorijaRepo : IKategorija
    {

        private readonly Data _dbContext;

        public KategorijaRepo(Data dbContext)
        {
            _dbContext = dbContext;
        }

        public Kategorija CreateKategorija(Kategorija kategorija)
        {
            _dbContext.Kategorije.Add(kategorija);
            _dbContext.SaveChanges();
            return kategorija;
        }

        public void DeleteKategorija(int id)
        {
            var kategorija = _dbContext.Kategorije.Find(id);
            if (kategorija != null)
            {
                _dbContext.Kategorije.Remove(kategorija);
                _dbContext.SaveChanges();
            }
        }

        public ICollection<Kategorija> GetAllKategorija()
        {
            return _dbContext.Kategorije.ToList();
        }

        public Kategorija GetKategorijaId(int id)
        {
            return _dbContext.Kategorije.Find(id);
        }

        public void UpdateKategorija(int id, Kategorija kategorija)
        {
            var existingKategorija = _dbContext.Kategorije.Find(id);
            if (existingKategorija != null)
            {
                existingKategorija.Naziv = kategorija.Naziv;
                _dbContext.SaveChanges();
            }
        }
    }
}