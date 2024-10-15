using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsEspecialidad
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Especialidad especialidad { get; set; }

		public Especialidad Consultar(int id)
		{
			return db.Especialidads.FirstOrDefault(e => e.idEspecialidad == id);
		}

		public string Insertar()
		{
			try
			{
				db.Especialidads.Add(especialidad);
				db.SaveChanges();
				return "Especilidad insertada satisfactoriamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			Especialidad _especialidad = Consultar(especialidad.idEspecialidad);

			try
			{
				if (_especialidad != null)
				{
					db.Especialidads.AddOrUpdate(especialidad);
					db.SaveChanges();
					return "Especilidad actualizada satisfactoriamente";
				}
				else
				{
					return "Especilidad no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Eliminar()
		{
			Especialidad _especialidad = Consultar(especialidad.idEspecialidad);

			try
			{
				if (_especialidad != null)
				{
					db.Especialidads.Remove(_especialidad);
					db.SaveChanges();
					return "Especilidad eliminada satisfactoriamente";
				}
				else
				{
					return "Especilidad no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
        public IQueryable ListarEspecialidad()
        {
			return from Es in db.Set<Especialidad>()
				   select new
				   {
					   ID = Es.idEspecialidad,
					   Nombre = Es.nombre
                       
                   };
        }
    }
}