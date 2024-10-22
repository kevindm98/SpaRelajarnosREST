using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsMetodoPago
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public clsMetodoPago metodoPago { get; set; }

		public List<MetodoPago> LlenarCombo()
		{
			return db.MetodoPagoes
				.OrderBy(ts => ts.Nombre)
				.ToList();
		}
	}
}