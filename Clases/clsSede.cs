using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsSede
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Sede  sede { get; set; }

        public Sede Consultar(int id)
        {
            return db.Sedes.FirstOrDefault(p => p.Id == id);
        }

        public string Insertar()
        {
            try
            {
                db.Sedes.Add(sede);
                db.SaveChanges();
                return "Sede insertado satisfactoriamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            Sede _producto = Consultar(sede.Id);

            try
            {
                if (_producto != null)
                {
                    db.Sedes.AddOrUpdate(sede);
                    db.SaveChanges();
                    return "Sede actualizada satisfactoriamente";
                }
                else
                {
                    return "Sede no encontrado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar()
        {
            Sede _producto = Consultar(sede.Id);

            try
            {
                if (_producto != null)
                {
                    db.Sedes.Remove(_producto);
                    db.SaveChanges();
                    return "Sede eliminado satisfactoriamente";
                }
                else
                {
                    return "Sede no encontrado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarTabla()
        {
            return from s in db.Set<Sede>()
                   join c in db.Set<Ciudad>()
                   on s.IdCiudad equals c.Id
                   orderby s.Nombre
                   select new
                   {
                       id = s.Id,
                       NombreSede = s.Nombre,
                       Direccion = s.Direccion,
                       Ciudad = c.Nombre,
                   };
        }

        public List<Sede> LlenarCombo()
		{
			return db.Sedes
				.OrderBy(ts => ts.Nombre)
				.ToList();
		}
	}
}