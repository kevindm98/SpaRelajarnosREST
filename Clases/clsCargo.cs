using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsCargo
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public clsCargo cargo { get; set; }

		public List<Cargo> LlenarCombo()
		{
			return db.Cargoes
				.OrderBy(ts => ts.Nombre)
				.ToList();
		}
	}
}