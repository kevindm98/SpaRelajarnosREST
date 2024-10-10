using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsReserva
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Reserva reserva { get; set; }

		public Reserva Consultar(int id)
		{
			return db.Reservas.FirstOrDefault(r => r.idReserva == id);
		}

		public string Insertar()
		{
			try
			{
				db.Reservas.Add(reserva);
				db.SaveChanges();
				return "Reserva insertada satisfactoriamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			Reserva _reserva = Consultar(reserva.idReserva);

			try
			{
				if (_reserva != null)
				{
					db.Reservas.AddOrUpdate(reserva);
					db.SaveChanges();
					return "Reserva actualizada satisfactoriamente";
				}
				else
				{
					return "Reserva no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Eliminar()
		{
			Reserva _reserva = Consultar(reserva.idReserva);

			try
			{
				if (_reserva != null)
				{
					db.Reservas.Remove(_reserva);
					db.SaveChanges();
					return "Reserva eliminada satisfactoriamente";
				}
				else
				{
					return "Reserva no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}