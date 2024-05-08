using BLL.Interface;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class KorisniciRepo : IKorisnik
    {
        private readonly Data _dbContext;

        public KorisniciRepo(Data dbContext)
        {
            _dbContext = dbContext;
        }

        public Korisnik CreateKorisnik(Korisnik korisnik)
        {
            _dbContext.Korisnici.Add(korisnik);
            _dbContext.SaveChanges();
            return korisnik;
        }

        public ICollection<Korisnik> GetAllKorisnik()
        {
            return _dbContext.Korisnici.ToList();
        }

        public void DeleteKorisnik(int id)
        {
            var korisnik = _dbContext.Korisnici.Find(id);
            if (korisnik != null)
            {
                _dbContext.Korisnici.Remove(korisnik);
                _dbContext.SaveChanges();
            }
        }

        public Korisnik GetKorisnikId(int id)
        {
            return _dbContext.Korisnici.Find(id);
        }

        public void UpdateKorisnik(int id, Korisnik korisnik)
        {
            var existingKorisnik = _dbContext.Korisnici.Find(id);
            if (existingKorisnik != null)
            {
                existingKorisnik.Ime = korisnik.Ime;
                existingKorisnik.Prezime = korisnik.Prezime;
                existingKorisnik.Email = korisnik.Email;
                existingKorisnik.Lozinka = korisnik.Lozinka;
                existingKorisnik.Broj_Mobitela = korisnik.Broj_Mobitela;
                existingKorisnik.Spol = korisnik.Spol;
                existingKorisnik.Datum_Rodenja = korisnik.Datum_Rodenja;

                _dbContext.SaveChanges();
            }
        }

    }
}
