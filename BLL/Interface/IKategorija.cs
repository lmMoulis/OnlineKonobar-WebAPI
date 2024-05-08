using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IKategorija
    {
        Kategorija CreateKategorija(Kategorija kategorija);
        ICollection<Kategorija> GetAllKategorija();
        Kategorija GetKategorijaId(int id);
        void UpdateKategorija(int id,Kategorija kategorija);
        void DeleteKategorija(int id);

    }
}
