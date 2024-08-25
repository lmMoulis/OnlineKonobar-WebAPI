using System.Collections.Generic;
using System.Linq;
using BLL.Interface;
using BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class NormativiRepo : INormativi
    {
        private readonly Data _dbContext;

        public NormativiRepo(Data dbContext)
        {
            _dbContext = dbContext;
        }

        public Normativi CreateNormativi(Normativi normativi)
        {
            _dbContext.Normativi.Add(normativi);
            _dbContext.SaveChanges();
            return normativi;
        }

        public ICollection<Normativi> GetAllNormativi()
        {
            return _dbContext.Normativi.ToList();
        }

        public void DeleteNormativi(int id)
        {
            var normativi = _dbContext.Normativi.Find(id);
            if (normativi != null)
            {
                _dbContext.Normativi.Remove(normativi);
                _dbContext.SaveChanges();
            }
        }

        public Normativi GetNormativiId(int id)
        {
            return _dbContext.Normativi.Find(id);
        }

        public void UpdateNormativi(int id, Normativi normativi)
        {
            var existingNormativi = _dbContext.Normativi.Find(id);
            if (existingNormativi != null)
            {
                existingNormativi.Artikal_Id = normativi.Artikal_Id;
                existingNormativi.Normativ = normativi.Normativ;
                existingNormativi.Naziv = normativi.Naziv;
                existingNormativi.Skladiste_Id = normativi.Skladiste_Id;

                _dbContext.SaveChanges();
            }
        }

        public List<Normativi> GetNormativByArticleId(int articleId)
        {
            return _dbContext.Normativi.Where(n => n.Artikal_Id == articleId).ToList();
        }
        public Normativi GetNormativiByArticleId(int artikalId)
        {
            return _dbContext.Normativi.FirstOrDefault(n => n.Artikal_Id == artikalId); // Provjerite da li vraća jedan objekt
        }
    }
}
