using System;
using BLL.Interface;
using BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class StavkaRepo : IStavka
	{
		private readonly Data _dbContext;
		public StavkaRepo(Data dbContext)
		{
			_dbContext = dbContext;
		}

        public Stavka CreateStavka(Stavka stavka)
		{
            _dbContext.Stavka.Add(stavka);
            _dbContext.SaveChanges();
            return stavka;
        }
        public ICollection<Stavka> GetAllStavka()
        {
            return _dbContext.Stavka.ToList();
        }
       

        public void DeleteStavka(string id)
        {
            var stavka = _dbContext.Stavka.Find(id);
            if (stavka != null)
            {
                _dbContext.Stavka.Remove(stavka);
                _dbContext.SaveChanges();
            }
        }

        public Stavka GetStavkaId(string id)
        {
            return _dbContext.Stavka.Find(id);
        }

        public void UpdateStavka(string id, Stavka stavka)
        {
            var existingStavka = _dbContext.Stavka.Find(id);
            if (existingStavka != null)
            {
                existingStavka.Order_Id = stavka.Order_Id;
                existingStavka.Artikal_Id = stavka.Artikal_Id;
                existingStavka.Korisnik_Id = stavka.Korisnik_Id;
                existingStavka.Dokument_id = stavka.Dokument_id;
                existingStavka.Kolicina = stavka.Kolicina;
                existingStavka.Dodatak_Id = stavka.Dodatak_Id;
                existingStavka.Cijena = stavka.Cijena;

                _dbContext.SaveChanges();
            }
        }
    }
}

