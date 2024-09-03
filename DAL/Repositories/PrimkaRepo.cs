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
    public class PrimkaRepo : IPrimka
    {
        private readonly Data _dbContext;
        public PrimkaRepo(Data dbContext)
        {
            _dbContext = dbContext;
        }

        public Primka CreatePrimka(Primka primka)
        {
            _dbContext.Primka.Add(primka);
            _dbContext.SaveChanges();
            return primka;
        }

        public ICollection<Primka> GetAllPrimka()
        {
            return _dbContext.Primka.ToList();
        }
        public ICollection<Primka> GetPrimkeByStockIdAndDate(int stockId, string date)
        {
            DateTime dateTime;
            if (!DateTime.TryParse(date, out dateTime))
            {
                throw new ArgumentException("Invalid date format.");
            }

            return _dbContext.Primka
                .Where(p => p.Artikal_Id == stockId && p.Datum.Date == dateTime.Date)
                .ToList();
        }
        public ICollection<Primka> GetReceiptsByDate(string date)
        {
            DateTime dateTime;
            if (!DateTime.TryParse(date, out dateTime))
            {
                throw new ArgumentException("Invalid date format.");
            }

            return _dbContext.Primka
                .Where(p => p.Datum.Date == dateTime.Date)
                .ToList();
        }

        public Primka GetPrimkaId(int id)
        {
            return _dbContext.Primka.Find(id);
        }
        public void UpdatePrimka(int id, Primka primka)
        {
            var existingPrimka = _dbContext.Primka.Find(id);
            if (existingPrimka != null)
            {
                existingPrimka.Artikal_Id = primka.Artikal_Id;
                existingPrimka.Kolicina= primka.Kolicina;
                existingPrimka.Datum= primka.Datum;
               
                _dbContext.SaveChanges();
            }
        }
        public void DeletePrimka(int id)
        {
            var primka = _dbContext.Primka.Find(id);
            if (primka != null)
            {
                _dbContext.Primka.Remove(primka);
                _dbContext.SaveChanges();
            }
        }
    }
}
