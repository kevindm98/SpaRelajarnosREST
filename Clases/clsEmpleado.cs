using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Http;

namespace SpaRelajarnosREST.Clases
{
	public class clsEmpleado
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Empleado empleado { get; set; }


		public Empleado Consultar(string documento)
		{
			return db.Empleadoes.FirstOrDefault(e => e.Documento.Equals(documento));
		}

        public Empleado ConsultarXid(int Id)
        {
            return db.Empleadoes.FirstOrDefault(e => e.Id.Equals(Id));
        }

        public IQueryable ConsultarConCargo(string documento) 
		{
			return from E in db.Set<Empleado>()
				   join C in db.Set<Cargo>()
				   on E.Cargo.Id equals C.Id
				   where E.Documento == documento
				   select new
				   {
					   Empleado = E.Nombre + " " + E.Apellido,
					   Id = E.Id,
					   Cargo = C.Nombre
				   };
		}

		[AllowAnonymous]
        public IQueryable ConsultarXUsuario(string Usuario)
        {
            return from E in db.Set<Empleado>()
                   join C in db.Set<Cargo>()
                   on E.Cargo.Id equals C.Id
				   join U in db.Set<Usuario>()
				   on E.Id equals U.Empleado.Id
				   where U.UserName == Usuario
                   select new
                   {
					   idEmpleado = E.Id,
                       Empleado = E.Nombre + " " + E.Apellido,
                       Cargo = C.Nombre
                   };
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
			Empleado _empleado = ConsultarXid(empleado.Id);

			try
			{
				if (_empleado != null)
				{
					empleado.Id = _empleado.Id;
					db.Entry(_empleado).CurrentValues.SetValues(empleado);
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
				return ex.ToString();
			}
		}

		public string Eliminar()
		{
			Empleado _empleado = Consultar(empleado.Documento);

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
				   join C in db.Set<Cargo>()
				   on E.Cargo.Id equals C.Id
				   join S in db.Set<Sede>()
				   on E.Sede.Id equals S.Id
				   orderby E.Nombre
                   select new
                   {
					   Id = E.Id,
                       Documento = E.Documento,
                       Empleado = E.Nombre + " " + E.Apellido,
					   Telefono = E.Telefono,
					   Email = E.Correo,
					   Salario = E.Salario,
					   Direccion = E.Direccion,
					   Cargo = C.Nombre,
					   Sede = S.Nombre,
					   fechaContratacion = E.FechaContratacion
				   };
        }
    }
}