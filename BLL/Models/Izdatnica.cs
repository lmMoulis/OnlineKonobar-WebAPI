using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    [Table("Izdatnice")]
    public class Izdatnica
    {
        public int Id { get; set; }
        public int Dokument_Id {  get; set; }
        public string Dobavljac {  get; set; }
        public int Kolicina { get; set; }
        public decimal Ukupan_Iznos { get; set; }

    }
}
