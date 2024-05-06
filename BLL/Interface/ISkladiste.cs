using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ISkladiste
    {
        Skladiste CreateSkladiste(Skladiste skladiste);
        ICollection<Skladiste> GetAllSkladiste();
        Skladiste GetSkladisteId(int id);
        void UpdateSkladiste(int id,Skladiste skladiste);
        void DeleteSkladiste(int id);



    }
}
