using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsProducto
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Producto producto { get; set; }

		public Producto Consultar(int id)
		{
			return db.Productoes.FirstOrDefault(p => p.Id == id);
		}

		public string Insertar()
		{
			try
			{
				db.Productoes.Add(producto);
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
			Producto _producto = Consultar(producto.Id);

			try
			{
				if (_producto != null)
				{
					db.Productoes.AddOrUpdate(producto);
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
			Producto _producto = Consultar(producto.Id);

			try
			{
				if (_producto != null)
				{
					db.Productoes.Remove(_producto);
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
            return from p in db.Set<Producto>()
                   join tp in db.Set<TipoProducto>()
                   on p.TipoProducto.Id equals tp.Id
                   orderby p.Nombre, tp.Nombre
                   select new
                   {
                       Cod_TipoServicio = tp.Id,
                       Tipo_Servicio = tp.Nombre,
                       Codigo = p.Id,
                       Servicio = p.Nombre,
                       Precio = p.Precio
                   };
        }

        public IQueryable ListarProductosXTipo(int TipoProducto)
        {
            return from P in db.Set<Producto>()
                   join TP in db.Set<TipoProducto>()
                   on P.TipoProducto.Id equals TP.Id
                   //Aca iría el where, si se requiere
                   where TP.Id == TipoProducto
                   orderby TP.Nombre, P.Nombre //Order by si se requiere
                   select new //Finalmente, se presentan los campos que se van a mostrar
                   {
                       Codigo = P.Id + "|" + P.Precio,
                       Nombre = P.Nombre
                   };
        }
    }
}