using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsTipoProducto
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public clsTipoProducto tipoProducto { get; set; }

		public List<TipoProducto> LlenarCombo()
		{
			return db.TipoProductoes
				.OrderBy(ts => ts.Nombre)
				.ToList();
		}
	}
}