using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IKorisnik
    {
        Korisnik CreateKorisnik(Korisnik korisnik);
        ICollection<Korisnik> GetAllKorisnik();
        Korisnik GetKorisnikId(int id);
        void UpdateKorisnik(int id, Korisnik korisnik);
        void DeleteKorisnik(int id);
    }
}
