using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Models
{
    [Table("Artikli")]
    public class Artikal
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public int Kategorija_Id { get; set; }
        public decimal Kolicina { get; set; }

    }
}
