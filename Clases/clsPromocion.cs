using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsPromocion
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Promocion promocion { get; set; }

		public Promocion Consultar(int id)
		{
			return db.Promocions.FirstOrDefault(p => p.idPromocion == id);
		}

		public string Insertar()
		{
			try
			{
				db.Promocions.Add(promocion);
				db.SaveChanges();
				return "Promoción insertada satisfactoriamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			Promocion _promocion = Consultar(promocion.idPromocion);

			try
			{
				if (_promocion != null)
				{
					db.Promocions.AddOrUpdate(promocion);
					db.SaveChanges();
					return "Promoción actualizada satisfactoriamente";
				}
				else
				{
					return "Promoción no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Eliminar()
		{
			Promocion _promocion = Consultar(promocion.idPromocion);

			try
			{
				if (_promocion != null)
				{
					db.Promocions.Remove(_promocion);
					db.SaveChanges();
					return "Promoción eliminada satisfactoriamente";
				}
				else
				{
					return "Promoción no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}