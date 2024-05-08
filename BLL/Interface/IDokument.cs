using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IDokument
    {
        Dokument CreateDokument(Dokument dokument);
        ICollection<Dokument> GetAllDokument();
        Dokument GetDokumentId(int id);
        void UpdateDokument(int id, Dokument dokument);
        void DeleteDokument(int id);

    }
}
