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
			return db.Productoes.FirstOrDefault(p => p.idProducto == id);
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
			Producto _producto = Consultar(producto.idProducto);

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
			Producto _producto = Consultar(producto.idProducto);

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
	}
}