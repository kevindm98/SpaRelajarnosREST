using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsCargo
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Cargo cargo { get; set; }

        public Cargo Consultar(int id)
        {
            return db.Cargoes.FirstOrDefault(p => p.Id == id);
        }

        public string Insertar()
        {
            try
            {
                db.Cargoes.Add(cargo);
                db.SaveChanges();
                return "Tipo Producto insertado satisfactoriamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            Cargo _producto = Consultar(cargo.Id);

            try
            {
                if (_producto != null)
                {
                    db.Cargoes.AddOrUpdate(cargo);
                    db.SaveChanges();
                    return "Tipo Producto actualizado satisfactoriamente";
                }
                else
                {
                    return "Tipo Producto no encontrado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar()
        {
            Cargo _producto = Consultar(cargo.Id);

            try
            {
                if (_producto != null)
                {
                    db.Cargoes.Remove(_producto);
                    db.SaveChanges();
                    return "Tipo Producto eliminado satisfactoriamente";
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
            return from c in db.Set<Cargo>()
                   orderby c.Nombre
                   select new
                   {
                       id = c.Id,
                       Cargo = c.Nombre,
                   };
        }

        public List<Cargo> LlenarCombo()
		{
			return db.Cargoes
                .OrderBy(ts => ts.Nombre)
				.ToList();
		}
	}
}