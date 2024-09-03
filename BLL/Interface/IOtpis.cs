using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IOtpis
    {
        Otpis CreateOtpis(Otpis otpis);
        ICollection<Otpis> GetAllOtpis();
        ICollection<Otpis> GetAdjustmentByStockIdAndDate(int stockId, string date);
        ICollection<Otpis> GetAdjustmentByDate(string date);
        Otpis GetOtpisId(int id);
        void UpdateOtpis(int id, Otpis otpis);
        void DeleteOtpis(int id);
    }
}
