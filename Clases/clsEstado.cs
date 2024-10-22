using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsEstado
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public clsEstado estado { get; set; }

		public List<Estado> LlenarCombo()
		{
			return db.Estadoes
				.OrderBy(ts => ts.Nombre)
				.ToList();
		}
	}
}