using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IStavka
    {
        Stavka CreateStavka (Stavka stavka);
        ICollection<Stavka> GetAllStavka ();
        Stavka GetStavkaId (Stavka stavka);
        void UpdateStavka (int id,Stavka stavka);
        void DeleteStavka (int id);
    }
}
