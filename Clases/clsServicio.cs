using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsServicio
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Servicio servicio { get; set; }

		public Servicio Consultar(int id)
		{
			return db.Servicios.FirstOrDefault(s => s.idServicio == id);
		}

		public string Insertar()
		{
			try
			{
				db.Servicios.Add(servicio);
				db.SaveChanges();
				return "Servicio insertado satisfactoriamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			Servicio _servicio = Consultar(servicio.idServicio);

			try
			{
				if (_servicio != null)
				{
					db.Servicios.AddOrUpdate(servicio);
					db.SaveChanges();
					return "Servicio actualizado satisfactoriamente";
				}
				else
				{
					return "Servicio no encontrado";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Eliminar()
		{
			Servicio _servicio = Consultar(servicio.idServicio);

			try
			{
				if (_servicio != null)
				{
					db.Servicios.Remove(_servicio);
					db.SaveChanges();
					return "Servicio eliminado satisfactoriamente";
				}
				else
				{
					return "Servicio no encontrado";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}