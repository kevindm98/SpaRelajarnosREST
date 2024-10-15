using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsEmpleado
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Empleado empleado { get; set; }

		public Empleado Consultar(int documento)
		{
			return db.Empleadoes.FirstOrDefault(e => e.documentoEmpleado == documento);
		}

		public string Insertar()
		{
			try
			{
				db.Empleadoes.Add(empleado);
				db.SaveChanges();
				return "Empleado insertado satisfactoriamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			Empleado _empleado = Consultar(empleado.documentoEmpleado);

			try
			{
				if (_empleado != null)
				{
					db.Empleadoes.AddOrUpdate(empleado);
					db.SaveChanges();
					return "Empleado actualizado satisfactoriamente";
				}
				else
				{
					return "Empleado no encontrado";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Eliminar()
		{
			Empleado _empleado = Consultar(empleado.documentoEmpleado);

			try
			{
				if (_empleado != null)
				{
					db.Empleadoes.Remove(_empleado);
					db.SaveChanges();
					return "Empleado eliminado satisfactoriamente";
				}
				else
				{
					return "Empleado no encontrado";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
        public IQueryable ListarEmpleados()
        {	
			return from E in db.Set<Empleado>()
				   join EE in db.Set<EspecialidadEmpleado>()
				   on E.documentoEmpleado equals EE.documentoEmpleado
				   join Es in db.Set<Especialidad>()
				   on EE.idEspecialidad equals Es.idEspecialidad
				   orderby E.nombre
                   select new
                   {
                       Documento = E.documentoEmpleado,
                       Empleado = E.nombre + " " + E.apellido,
                       Cargo = E.cargo,
					   Salario = E.salario,
                       Especialidad = Es.nombre  
                   };
        }

    }
}