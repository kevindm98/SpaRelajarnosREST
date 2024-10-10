using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsFacturacion
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Facturacion facturacion { get; set; }

		public Facturacion Consultar(int id)
		{
			return db.Facturacions.FirstOrDefault(f => f.idFactura == id);
		}

		public string Insertar()
		{
			try
			{
				db.Facturacions.Add(facturacion);
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
			Facturacion _facturacion = Consultar(facturacion.idFactura);

			try
			{
				if (_facturacion != null)
				{
					db.Facturacions.AddOrUpdate(facturacion);
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
			Facturacion _facturacion = Consultar(facturacion.idFactura);

			try
			{
				if (_facturacion != null)
				{
					db.Facturacions.Remove(_facturacion);
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