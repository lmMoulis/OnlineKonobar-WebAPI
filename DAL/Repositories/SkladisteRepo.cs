using System;
using BLL.Interface;
using BLL.Models;

namespace DAL.Repositories
{
	public class SkladisteRepo :ISkladiste
	{
		private readonly Data _dbContext;
		public SkladisteRepo(Data dbContext)

		{
			_dbContext = dbContext;
		}
		public Skladiste CreateSkladiste(Skladiste skladiste)
		{
			_dbContext.StanjeSkladista.Add(skladiste);
			_dbContext.SaveChanges();
			return skladiste;
		}
		public ICollection<Skladiste>GetAllSkladiste()
		{
			return _dbContext.StanjeSkladista.ToList();

        }
		public void DeleteSkladiste(int id)
		{
			var skladiste = _dbContext.StanjeSkladista.Find(id);
			if(skladiste != null)
			{
				_dbContext.StanjeSkladista.Remove(skladiste);
				_dbContext.SaveChanges();
			}
		}
		public Skladiste GetSkladisteId(int id)
		{
			return _dbContext.StanjeSkladista.Find(id);
		}
		public void UpdateSkladiste(int id,Skladiste skladiste)
		{
			var existingSkladiste = _dbContext.StanjeSkladista.Find(id);
			if(existingSkladiste !=null)
			{
				existingSkladiste.Id = skladiste.Id;
				existingSkladiste.Artikal = skladiste.Artikal;
				existingSkladiste.Dokument_Id = skladiste.Dokument_Id;
				existingSkladiste.Korisnik_Id = skladiste.Korisnik_Id;
				existingSkladiste.Kolicina = skladiste.Kolicina;
				existingSkladiste.Slike=skladiste.Slike;

				_dbContext.SaveChanges();
			}

        }

	}
}

