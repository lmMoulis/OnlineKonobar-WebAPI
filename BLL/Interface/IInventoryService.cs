using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IInventoryService
    {
        double CalculateDaysRemaining(int artikalId);
        List<ArtikalDaysRemaining> CalculateDaysRemainingForAll();
    }
    public class ArtikalDaysRemaining
    {
        public int ArtikalId { get; set; }
        public string ArtikalNaziv { get; set; }
        public double DaysRemaining { get; set; }
    }
}
