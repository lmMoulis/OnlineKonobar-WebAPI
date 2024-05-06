using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IRacun
    {
        Racun CreateRacun(Racun racun);
        ICollection<Racun> GetAllRAcun();
        Racun GetRacunId(int id);
        void UpdateRacun(int id,Racun racun);
        void DeleteRacun(int id);


    }
}
