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
        public int Id { get; set; }
        public int Dokument_Id { get; set; }
        public string Broj_Racuna { get; set; }
        public decimal Ukupan_Iznos { get; set; }
        public DateTime Datum { get; set; }
        public int Korisnik_Id { get; set; }
        public string Status { get; set; }

    }
}
