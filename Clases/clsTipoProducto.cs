using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsTipoProducto
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public TipoProducto tipoProducto { get; set; }


        public TipoProducto Consultar(int id)
        {
            return db.TipoProductoes.FirstOrDefault(p => p.Id == id);
        }

        public string Insertar()
        {
            try
            {
                db.TipoProductoes.Add(tipoProducto);
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
            TipoProducto _producto = Consultar(tipoProducto.Id);

            try
            {
                if (_producto != null)
                {
                    db.TipoProductoes.AddOrUpdate(tipoProducto);
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
            TipoProducto _producto = Consultar(tipoProducto.Id);

            try
            {
                if (_producto != null)
                {
                    db.TipoProductoes.Remove(_producto);
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
            return from tp in db.Set<TipoProducto>()
                   orderby tp.Nombre
                   select new
                   {
                       id = tp.Id,
                       TipoProducto = tp.Nombre,
                   };
        }


        public List<TipoProducto> LlenarCombo()
		{
			return db.TipoProductoes
				.OrderBy(ts => ts.Nombre)
				.ToList();
		}
	}
}