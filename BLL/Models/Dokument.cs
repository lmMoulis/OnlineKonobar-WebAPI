using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    [Table("Dokumenti")]
    public class Dokument
    {
        public int Id { get; set; }
        public int Korisnik_Id {  get; set; }
        public DateTime Datum { get; set; }
        public string Tip { get; set; }



    }
}
