using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsProveedor
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Proveedor proveedor { get; set; }

		public Proveedor Consultar(int id)
		{
			return db.Proveedors.FirstOrDefault(c => c.idProveedor == id);
		}

		public string Insertar()
		{
			try
			{
				db.Proveedors.Add(proveedor);
				db.SaveChanges();
				return "Proveedor insertado satisfactoriamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			Proveedor _proveedor = Consultar(proveedor.idProveedor);

			try
			{
				if (_proveedor != null)
				{
					db.Proveedors.AddOrUpdate(proveedor);
					db.SaveChanges();
					return "Proveedor actualizado satisfactoriamente";
				}
				else
				{
					return "Proveedor no encontrado";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Eliminar()
		{
			Proveedor _proveedor = Consultar(proveedor.idProveedor);

			try
			{
				if (_proveedor != null)
				{
					db.Proveedors.Remove(_proveedor);
					db.SaveChanges();
					return "Proveedor eliminado satisfactoriamente";
				}
				else
				{
					return "Proveedor no encontrado";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}