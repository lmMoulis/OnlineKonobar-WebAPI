using System;
using BLL.Interface;
using BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class PrilagodbaRepo : IPrilagodba
	{
		private readonly Data _dbContext;
		public PrilagodbaRepo(Data dbContext)
		{
			_dbContext = dbContext;
		}

        public Prilagodba CreatePrilagodba(Prilagodba prilagodba)
        {
            _dbContext.Prilagodbe.Add(prilagodba);
            _dbContext.SaveChanges();
            return prilagodba;
        }

        public ICollection<Prilagodba> GetAllPrilagodba()
        {
            return _dbContext.Prilagodbe.ToList();
        }

        public void DeletePrilagodba(int id)
        {
            var prialgodba = _dbContext.Prilagodbe.Find(id);
            if (prialgodba != null)
            {
                _dbContext.Prilagodbe.Remove(prialgodba);
                _dbContext.SaveChanges();
            }
        }

        public Prilagodba GetPrilagodbaId(int id)
        {
            return _dbContext.Prilagodbe.Find(id);
        }

        public void UpdatePrilagodba(int id, Prilagodba prilagodba)
        {
            var existingPrilagodba = _dbContext.Prilagodbe.Find(id);
            if (existingPrilagodba != null)
            {
                existingPrilagodba.Naziv = prilagodba.Naziv;
                existingPrilagodba.Id_Kategorije = prilagodba.Id_Kategorije;
               
                _dbContext.SaveChanges();
            }
        }

    }
}

