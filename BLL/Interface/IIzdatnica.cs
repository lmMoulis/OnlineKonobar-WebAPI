using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IIzdatnica
    {
        Izdatnica CreateIzdatnica(Izdatnica izdatnica);
        ICollection<Izdatnica>GetAllIzdatnica();
        Izdatnica GetIzdatnicaId(int id);
        void UpdateIzdatnica(int id,Izdatnica izdatnica);
        void DeleteIzdatnica(int id);

    }
}
