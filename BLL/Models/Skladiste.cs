using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    [Table("Skladiste")]
    public class Skladiste
    {
        [Key]
       public int Artikal_Id { get; set; }
       public int Dokument_Id { get; set; }
       public int Korisnik_Id { get; set; }
       public int Kolicina_Id { get; set; }
    }
}
