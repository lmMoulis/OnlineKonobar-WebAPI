using System;
using BLL.Models;

namespace BLL.Interface
	
{
	public interface IPrilagodba
	{
		Prilagodba CreatePrilagodba(Prilagodba prilagodba);
		ICollection<Prilagodba> GetAllPrilagodba();
		Prilagodba GetPrilagodbaId(int id);
		void UpdatePrilagodba(int id, Prilagodba prilagodba);
		void DeletePrilagodba(int id);
	}
}

