using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    [Table("Stavke")]
    public class Stavka
    {
        public int Id { get; set; }
        public string Order_Id { get; set; }
        public int Artikal_Id { get; set; }
        public int Korisnik_Id { get; set; }
        public int Dokument_id { get; set; }
        public int Kolicina { get; set; }
        public int? Dodatak_Id { get; set; }
        public decimal Cijena { get; set; }
        

    }
}
