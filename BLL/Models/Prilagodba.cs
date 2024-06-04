using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Models
{
	[Table("Prilagodba")]
    public class Prilagodba
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public int Id_Kategorije { get; set; }
	}
	
}

