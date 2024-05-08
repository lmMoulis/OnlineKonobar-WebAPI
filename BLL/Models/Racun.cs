using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    [Table("Racuni")]
    public class Racun
    {
        public int Dokument_Id { get; set; }
        public string Broj_Racuna { get; set; }
        public double Ukupan_Iznos { get; set; }

    }
}
