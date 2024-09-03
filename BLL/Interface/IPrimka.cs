using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IPrimka
    {
        Primka CreatePrimka(Primka primka);
        ICollection<Primka> GetAllPrimka();
        ICollection<Primka> GetPrimkeByStockIdAndDate(int stockId, string date);
        ICollection<Primka> GetReceiptsByDate(string date);
        Primka GetPrimkaId(int id);
        void UpdatePrimka(int id, Primka primka);
        void DeletePrimka(int id);
        
    }
}
