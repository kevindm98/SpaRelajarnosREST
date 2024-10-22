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


		public Empleado Consultar(int id)
		{
			return db.Empleadoes.FirstOrDefault(e => e.Id == id);
		}

		public string Insertar(int IdEspecialidad)
		{
			try
			{
				EspecialidadEmpleado especialidadEmpleado = new EspecialidadEmpleado();
				especialidadEmpleado.Id = IdEspecialidad;
				especialidadEmpleado.Id = empleado.Id;
				db.EspecialidadEmpleadoes.Add(especialidadEmpleado);
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
			Empleado _empleado = Consultar(empleado.Id);

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
			Empleado _empleado = Consultar(empleado.Id);

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
				   on E.Id equals EE.Id
				   join Es in db.Set<Especialidad>()
				   on EE.Id equals Es.Id
				   orderby E.Nombre
                   select new
                   {
                       Documento = E.Id,
                       Empleado = E.Nombre + " " + E.Apellido,
                       Cargo = E.Cargo,
					   Salario = E.Salario,
                       Especialidad = Es.Nombre  
                   };
        }
		public List<Especialidad> LlenarCombo()
		{
			return db.Especialidads
				.OrderBy(ts => ts.Nombre)
				.ToList();
		}

	}
}