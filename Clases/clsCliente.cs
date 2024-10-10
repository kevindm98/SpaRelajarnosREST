using System;
using SpaRelajarnosREST.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace SpaRelajarnosREST.Clases
{
	public class clsCliente
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Cliente cliente { get; set; }

		public Cliente Consultar(int documento)
		{
			return db.Clientes.FirstOrDefault(c => c.documentoCliente == documento);
		}

		public string Insertar()
		{
			try
			{
				db.Clientes.Add(cliente);
				db.SaveChanges();
				return "Cliente insertado satisfactoriamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			Cliente _cliente = Consultar(cliente.documentoCliente);

			try
			{
				if (_cliente != null)
				{
					db.Clientes.AddOrUpdate(cliente);
					db.SaveChanges();
					return "Cliente actualizado satisfactoriamente";
				}
				else
				{
					return "Cliente no encontrado";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Eliminar()
		{
			Cliente _cliente = Consultar(cliente.documentoCliente);

			try
			{
				if (_cliente != null)
				{
					db.Clientes.Remove(_cliente);
					db.SaveChanges();
					return "Cliente eliminado satisfactoriamente";
				}
				else
				{
					return "Cliente no encontrado";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

	}
}