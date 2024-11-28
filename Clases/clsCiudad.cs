using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsCiudad
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Ciudad ciudad { get; set; }

        public Ciudad Consultar(int id)
        {
            return db.Ciudads.FirstOrDefault(p => p.Id == id);
        }

        public string Insertar()
        {
            try
            {
                db.Ciudads.Add(ciudad);
                db.SaveChanges();
                return "Producto insertado satisfactoriamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            Ciudad _ciudad = Consultar(ciudad.Id);

            try
            {
                if (_ciudad != null)
                {
                    db.Ciudads.AddOrUpdate(ciudad);
                    db.SaveChanges();
                    return "Producto actualizado satisfactoriamente";
                }
                else
                {
                    return "Producto no encontrado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar()
        {
            Ciudad _ciudad = Consultar(ciudad.Id);

            try
            {
                if (_ciudad != null)
                {
                    db.Ciudads.Remove(_ciudad);
                    db.SaveChanges();
                    return "Producto eliminado satisfactoriamente";
                }
                else
                {
                    return "Producto no encontrado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarTabla()
        {
            return from c in db.Set<Ciudad>()                   
                   orderby c.Nombre
                   select new
                   {
                       id = c.Id,
                       Ciudad = c.Nombre
                   };
        }
        public List<Ciudad> LlenarCombo()
		{
			return db.Ciudads
				.OrderBy(ts => ts.Nombre)
				.ToList();
		}
	}
}