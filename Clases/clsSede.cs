using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsSede
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public clsSede sede { get; set; }

		public List<Sede> LlenarCombo()
		{
			return db.Sedes
				.OrderBy(ts => ts.Nombre)
				.ToList();
		}
	}
}