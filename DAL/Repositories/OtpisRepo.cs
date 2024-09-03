using BLL.Interface;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OtpisRepo : IOtpis
    {
        private readonly Data _dbContext;
        public OtpisRepo(Data dbContext)
        {
            _dbContext = dbContext;
        }

        public Otpis CreateOtpis(Otpis otpis)
        {
            _dbContext.Otpis.Add(otpis);
            _dbContext.SaveChanges();
            return otpis;
        }

        public ICollection<Otpis> GetAllOtpis()
        {
            return _dbContext.Otpis.ToList();
        }
        public ICollection<Otpis> GetAdjustmentByStockIdAndDate(int stockId, string date)
        {
            DateTime dateTime;
            if (!DateTime.TryParse(date, out dateTime))
            {
                throw new ArgumentException("Invalid date format.");
            }

            return _dbContext.Otpis
                .Where(p => p.Artikal_Id == stockId && p.Datum.Date == dateTime.Date)
                .ToList();
        }
        public ICollection<Otpis> GetAdjustmentByDate(string date)
        {
            DateTime dateTime;
            if (!DateTime.TryParse(date, out dateTime))
            {
                throw new ArgumentException("Invalid date format.");
            }

            return _dbContext.Otpis
                .Where(p => p.Datum.Date == dateTime.Date)
                .ToList();
        }

        public Otpis GetOtpisId(int id)
        {
            return _dbContext.Otpis.Find(id);
        }
        public void UpdateOtpis(int id, Otpis otpis)
        {
            var existingOtpis = _dbContext.Otpis.Find(id);
            if (existingOtpis != null)
            {
                existingOtpis.Artikal_Id = otpis.Artikal_Id;
                existingOtpis.Kolicina = otpis.Kolicina;
                existingOtpis.Datum = otpis.Datum;

                _dbContext.SaveChanges();
            }
        }
        public void DeleteOtpis(int id)
        {
            var otpis = _dbContext.Otpis.Find(id);
            if (otpis != null)
            {
                _dbContext.Otpis.Remove(otpis);
                _dbContext.SaveChanges();
            }
        }
    }
}
