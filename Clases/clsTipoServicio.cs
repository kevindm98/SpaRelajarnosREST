using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsTipoServicio
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public clsTipoServicio tipoServicio { get; set; }

		public List<TipoServicio> LlenarCombo()
		{
			return db.TipoServicios
				.OrderBy(ts => ts.nombre)
				.ToList();
		}
	}
}