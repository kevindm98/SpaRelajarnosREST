using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Http;

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
				   on s.TipoServicio.Id equals ts.Id
				   orderby s.Nombre, ts.Nombre
				   select new
				   {
					   Cod_TipoServicio = ts.Id,
					   Tipo_Servicio = ts.Nombre,
					   Codigo = s.Id,
					   Servicio = s.Nombre,
					   Descripcion = s.Descripcion,
					   Precio = s.Precio
				   };
		}
		[AllowAnonymous]
        public IQueryable ListarServiciosXTipo(int TipoServicio)
        {
            //En SQL la instrucción es SELECT - FROM - WHERE
            //En linq la instrucción es FROM - WHERE - SELECT
            return from P in db.Set<Servicio>()
                   join TS in db.Set<TipoServicio>()
                   on P.TipoServicio.Id equals TS.Id
                   //Aca iría el where, si se requiere
                   where TS.Id == TipoServicio
                   orderby TS.Nombre, P.Nombre //Order by si se requiere
                   select new //Finalmente, se presentan los campos que se van a mostrar
                   {
                       Codigo = P.Id + "|" + P.Precio,
                       Nombre = P.Nombre
                   };
        }
    }
}