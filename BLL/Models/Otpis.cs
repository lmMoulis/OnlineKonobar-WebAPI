using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    [Table("Otpis")]
    public class Otpis
    {
        public int Id { get; set; }
        public int Artikal_Id {  get; set; }
        public int Kolicina { get; set; }
        public DateTime Datum { get; set; }
    }
}
