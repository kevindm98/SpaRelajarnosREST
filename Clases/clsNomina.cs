using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsNomina
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Nomina nomina { get; set; }

		public Nomina Consultar(int id)
		{
			return db.Nominas.FirstOrDefault(n => n.idNomina == id);
		}

		public string Insertar()
		{
			try
			{
				db.Nominas.Add(nomina);
				db.SaveChanges();
				return "Nómina insertada satisfactoriamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			Nomina _nomina = Consultar(nomina.idNomina);

			try
			{
				if (_nomina != null)
				{
					db.Nominas.AddOrUpdate(nomina);
					db.SaveChanges();
					return "Nómina actualizada satisfactoriamente";
				}
				else
				{
					return "Nómina no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Eliminar()
		{
			Nomina _nomina = Consultar(nomina.idNomina);

			try
			{
				if (_nomina != null)
				{
					db.Nominas.Remove(_nomina);
					db.SaveChanges();
					return "Nómina eliminada satisfactoriamente";
				}
				else
				{
					return "Nómina no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}