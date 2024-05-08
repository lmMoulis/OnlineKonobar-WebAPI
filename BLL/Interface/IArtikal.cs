using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IArtikal
    {
        Artikal CreateArtikal( Artikal artikal );
        ICollection<Artikal>GetAllArtikal();
        Artikal GetArtikaldId(int id);
        void UpdateArtikal(int id,Artikal artikal);
        void DeleteArtikal(int id);

    }
}
