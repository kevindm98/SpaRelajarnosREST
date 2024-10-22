using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsFacturaReserva
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public FacturaReserva facturaReserva { get; set; }

		public FacturaReserva Consultar(int id)
		{
			return db.FacturaReservas.FirstOrDefault(f => f.Id == id);
		}

		public string Insertar()
		{
			try
			{
				db.FacturaReservas.Add(facturaReserva);
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
			FacturaReserva _factura = Consultar(facturaReserva.Id);

			try
			{
				if (_factura != null)
				{
					db.FacturaReservas.AddOrUpdate(facturaReserva);
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
			FacturaReserva _factura = Consultar(facturaReserva.Id);

			try
			{
				if (_factura != null)
				{
					db.FacturaReservas.Remove(_factura);
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