using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models
{
    [Table("Normativi")]
    public class Normativi
    {
        [Key]
        public int Id { get; set; }
        public int Artikal_Id { get; set; }
        public int Normativ { get; set; }
        public string Naziv { get; set; }
        public int Skladiste_Id { get; set; }
    }
}

