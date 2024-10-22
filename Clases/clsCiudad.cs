using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsCiudad
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public clsCiudad ciudad { get; set; }

		public List<Ciudad> LlenarCombo()
		{
			return db.Ciudads
				.OrderBy(ts => ts.Nombre)
				.ToList();
		}
	}
}