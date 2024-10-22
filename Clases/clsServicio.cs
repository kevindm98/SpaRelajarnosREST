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
			return db.Servicios.FirstOrDefault(s => s.Id == id);
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
			Servicio _servicio = Consultar(servicio.Id);

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
			Servicio _servicio = Consultar(servicio.Id);

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

		public IQueryable LlenarTabla()
		{
			return from s in db.Set<Servicio>()
				   join ts in db.Set<TipoServicio>()
				   on s.Id equals ts.Id
				   orderby s.Nombre, ts.Nombre
				   select new
				   {
					   Cod_TipoServicio = ts.Id,
					   Tipo_Servicio = ts.Nombre,
					   Codigo = s.Id,
					   Servicio = s.Nombre,
					   Descripcion = s.Descripcion,
					   Precio = s.Precio,
					   Duracion_Servicio = s.DuracionMinutos
				   };
		}
	}
}