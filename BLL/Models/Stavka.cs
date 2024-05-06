using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Stavka
    {
        public int Id { get; set; }
        public int Artikal_Id { get; set; }
        public int Dokument_id { get; set; }
        public int Kolicina { get; set; }


    }
}
