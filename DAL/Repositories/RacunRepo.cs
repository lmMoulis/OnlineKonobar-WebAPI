using System;
using BLL.Interface;
using BLL.Models;

namespace DAL.Repositories
{
	public class RacunRepo:IRacun
	{
		private readonly Data _dbContext;
		public RacunRepo(Data dbContext)
		{
			_dbContext = dbContext;
		}
		public Racun CreateRacun(Racun racun)
		{
			_dbContext.Racuni.Add(racun);
			_dbContext.SaveChanges();
			return racun;
		}
		public ICollection<Racun> GetAllRacun()
		{
			return _dbContext.Racuni.ToList();
		}
		public void DeleteRacun(int id)
		{
			var racun = _dbContext.Racuni.Find(id);
			if(racun !=null)
			{
				_dbContext.Racuni.Remove(racun);
				_dbContext.SaveChanges();
			}
		}
		public Racun GetRacunId(int id)
		{
			return _dbContext.Racuni.Find(id);
		}
		public void UpdateRacun(int id,Racun racun)
		{
			var existingRacun = _dbContext.Racuni.Find(id);
			if(existingRacun!=null)
			{
				existingRacun.Id = racun.Id;
				existingRacun.Dokument_Id = racun.Dokument_Id;
				existingRacun.Broj_Racuna = racun.Broj_Racuna;
				existingRacun.Ukupan_Iznos = racun.Ukupan_Iznos;
				existingRacun.Datum = racun.Datum;
				existingRacun.Korisnik_Id = racun.Korisnik_Id;
				existingRacun.Status = racun.Status;
				_dbContext.SaveChanges();
			}

        }
    }
	
}

