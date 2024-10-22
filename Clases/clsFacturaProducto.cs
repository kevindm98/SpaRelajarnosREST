using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsFacturaProducto
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public FacturaProducto facturaProducto { get; set; }

		public FacturaProducto Consultar(int id)
		{
			return db.FacturaProductoes.FirstOrDefault(f => f.Id == id);
		}

		public string Insertar()
		{
			try
			{
				db.FacturaProductoes.Add(facturaProducto);
				db.SaveChanges();
				return "Factura insertada satisfactoriamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			FacturaProducto _factura = Consultar(facturaProducto.Id);

			try
			{
				if (_factura != null)
				{
					db.FacturaProductoes.AddOrUpdate(facturaProducto);
					db.SaveChanges();
					return "Factura actualizada satisfactoriamente";
				}
				else
				{
					return "Factura no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Eliminar()
		{
			FacturaProducto _factura = Consultar(facturaProducto.Id);

			try
			{
				if (_factura != null)
				{
					db.FacturaProductoes.Remove(_factura);
					db.SaveChanges();
					return "Factura eliminada satisfactoriamente";
				}
				else
				{
					return "Factura no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}